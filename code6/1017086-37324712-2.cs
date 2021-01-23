    [HttpGet]
    public IHttpActionResult Test()
    {
        var stream = new MemoryStream();
        var content = new StreamContent(stream);
        // ...
        // stream.Write(...);
        // ...
        return Ok(content);            
    }
