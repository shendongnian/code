    [HttpGet]
    [EnableQuery]
    public IHttpActionResult SomeFunction()
    {
        return Ok(products.FirstOrDefault(c => c.ID == 1));
    }
