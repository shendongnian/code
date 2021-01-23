    private readonly ConcurrentDictionary<string, SemaphoreSlim> _keyLocks = new ConcurrentDictionary<string, SemaphoreSlim>();
    private readonly Dictionary<string, Store> _cache = new Dictionary<string, Store>();
    public async Task<Store> GetStoreByUsernameAsync(string username)
    {	
    	Store value;
        // get the semaphore specific to this username
    	var keyLock = _keyLocks.GetOrAdd(username, x => new SemaphoreSlim(1));
      	await keyLock.WaitAsync();
    	try
    	{
    		// try to get Store from cache
    		if (!_cache.TryGetValue(username, out value))
    		{
    			// if value isn't cached, get it from the DB asynchronously
    			value = await _storeRepository.GetSingleAsync(x => x.UserName == username);
    	
    			// cache value
    			_cache.Add(username, value);
    		}
    	}
    	finally
    	{
    		keyLock.Release();
    	}
    	return value;
    }
