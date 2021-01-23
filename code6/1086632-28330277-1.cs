    public async Task<IHttpActionResult> Get(JObject q)
    {
        dynamic query = q; // cast to dynamic
        foreach(var @group in query.Groups)
        {
            var op = @group.Operator; // or group["Operator"]
            // do something
        }
    
        throw new NotImplementedException();
    }
