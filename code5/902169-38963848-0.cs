    // POST api/values
    public IHttpActionResult Post(JObject content)
    {
        var test = content.ToObject<TestSerialization>();
        // now you have your object with the properties filled correctly.
        return Ok();
    }
