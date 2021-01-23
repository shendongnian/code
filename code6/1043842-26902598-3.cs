    [HttpGet]
    [Route("api/blabla/SearchSomething")]
    public async Task<IHttpActionResult> Get([FromUri]SearchOptions searchOptions) {
        ...
    
        return Ok(results);
    }
