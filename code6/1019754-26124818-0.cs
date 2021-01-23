    public async Task<KeyValuePair<string, object>> LoadResultAsync(string query)
    {
        object result = null;
        // Async query setting result 
        return new KeyValuePair<string, object>(query, result)
    }
    public async Task<IDictionary<string, object>> Read(string[] queries)
    {
        var tasks = queries.Select(LoadNamedResultAsync);
        var results = await Task.WhenAll(tasks);
        return results.ToDictionary(r => r.Key, r => r.Value);
    }
