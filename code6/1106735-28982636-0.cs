    [HttpPut]
    [Route("SetCodesAsUnUsed/{codes}")]
    public HttpResponseMessage SetCodesAsUnUsed(List<string> codes)
    
    [HttpPut]
    [Route("SetCodesAsUsed/{codes}")]
    public HttpResponseMessage SetCodesAsUsed(List<string> codes)
