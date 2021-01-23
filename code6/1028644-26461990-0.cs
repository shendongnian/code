    [HttpGet]
    [EnableQuery]
    public IHttpActionResult SomeFunction()
    {
        return Ok(products.Where(c => c.ID == 1));
    }
