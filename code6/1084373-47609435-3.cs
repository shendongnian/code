    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> delta)
    {
        var patch = delta.ExcludeNonEditable();
        // TODO: Your patching action here
    }
