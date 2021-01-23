    [ValidateRequest]
    [HttpPut]
    [Route("api/businessname")]
    [Authorize]
    public HttpResponseMessage UpdateBusinessName(BusinessNameDto model) {
        ...
    }
