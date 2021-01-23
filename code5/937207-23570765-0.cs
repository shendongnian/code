    [HttpPost]
    [Route("search")]
    public HttpResponseMessage Search([FromBody] string term, 
                                     [FromBody] string category // this wouldn't work)
    {
        // Code ommited for brevity.
    }
