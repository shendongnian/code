    private readonly ConcurrentDictionary<string, AsyncLazy<string>> _cache
        = new ConcurrentDictionary<string, AsyncLazy<string>>();
    
    public async Task<string> GetStuffAsync(string url)
    {
        return await _cache.GetOrAdd(url,
    		new AsyncLazy<string>(
    			() => GetStuffInternalAsync(url),
    			LazyThreadSafetyMode.ExecutionAndPublication));
    }
