    [Route(Template = "{id}", Name = "GetThingById")]
    public IHttpActionResult Get(int id) {
         return Ok();
    }
    public IHttpActionResult DoStuff() {
        return Ok(Url.Link("GetThingById", new { id = 5 });
    }
