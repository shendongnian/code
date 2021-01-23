    private async Task<IHttpActionResult> UseHttpCache(Func<Task<IHttpActionResult>> operation)
    {
        IHttpActionResult result = await operation();
        var maxAge = TimeSpan.FromHours(1);
        return new CachedResult(result, maxAge);
    }
