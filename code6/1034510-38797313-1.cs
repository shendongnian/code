    public IHttpActionResult GetValue([FromUri]QueryParameters param)    
    {
        // Do Something with param.Capability,
        // except assign it a new value because it's only a getter
    }
