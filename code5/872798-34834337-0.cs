    private readonly ConcurrentDictionary<string, SemaphoreSlim> _keyLocks = new ConcurrentDictionary<string, SemaphoreSlim>();
    private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();
    public async Task<string> GetSomethingAsync(string key)
    {	
    	string value;
        // get the semaphore specific to this key
    	var keyLock = _keyLocks.GetOrAdd(key, new SemaphoreSlim(1));
      	await keyLock.WaitAsync();
    	try
    	{
    		// try to get value from cache
    		if (!_cache.TryGetValue(key, out value))
    		{
    			// if value isn't cached, get it the long way asynchronously
    			value = await GetSomethingTheLongWayAsync();
    	
    			// cache value
    			_cache.Add(key, value);
    		}
    	}
    	finally
    	{
    		keyLock.Release();
    	}
    	return value;
    }
