    [ResponseType(typeof(IEnumerable<Value>))]
    public IHttpActionResult GetThis()
    {
        Values values = new Values();
        return Ok(values);
    }
