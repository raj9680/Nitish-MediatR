using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Domain.Entities;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public EmployeeController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await _mediatr.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _mediatr.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var result = await _mediatr.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid id, Employee employee)
        {
            var result = await _mediatr.Send(new UpdateEmployeeCommand(employee, id));
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid id)
        {
            var result = await _mediatr.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
