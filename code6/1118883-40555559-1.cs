    public async Task<IHttpActionResult> GetSomething(string id)
    {
        var value = await GetAsyncResult(id);
        // cache result for 60 seconds
        return new CachedOkResult<string>(value, TimeSpan.FromSeconds(60), this);
    }
