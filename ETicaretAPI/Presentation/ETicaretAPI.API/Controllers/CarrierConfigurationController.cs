﻿using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier;
using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.CreateCarrierConfigurations;
using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.RemoveCarrierConfigurations;
using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.UpdateCarrierConfigurations;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        readonly private IMediator _mediator;
        public CarrierConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierConfigurationCommandRequest createCarrierConfigurationCommandRequest)
        {
            CreateCarrierConfigurationCommandResponse response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierConfigurationCommandRequest removeCarrierConfigurationsCommandRequest)
        {
            RemoveCarrierConfigurationCommandResponse response = await _mediator.Send(removeCarrierConfigurationsCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationsCommandRequest)
        {
            UpdateCarrierConfigurationCommandResponse response = await _mediator.Send(updateCarrierConfigurationsCommandRequest);
            return Ok();
        }
    }
}