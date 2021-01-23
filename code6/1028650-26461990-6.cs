    [HttpPost]
    [EnableQuery(PageSize=10)]
    public IHttpActionResult SomeFunction()
    {
        var results = db.SomeStoredProc().ToList();
        return Ok(results);
    }
