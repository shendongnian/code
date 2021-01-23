    [HttpGet]
    [Route("api/blabla/SearchSomething")]
    public async Task<IHttpActionResult> Get([FromUrl]SearchOptions searchOptions) {
        ...
    
        return Ok(results);
    }
