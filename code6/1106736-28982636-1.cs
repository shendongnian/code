    [HttpPut]
    [Route("api/ExternalCodes/SetCodesAsUnUsed")]
    public HttpResponseMessage SetCodesAsUnUsed(List<string> codes)
    
    [HttpPut]
    [Route("api/ExternalCodes/SetCodesAsUsed")]
    public HttpResponseMessage SetCodesAsUsed(List<string> codes)
