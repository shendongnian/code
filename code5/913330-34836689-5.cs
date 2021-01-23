    private readonly ConcurrentDictionary<string, SemaphoreSlim> _keyLocks = new ConcurrentDictionary<string, SemaphoreSlim>();
    private readonly ConcurrentDictionary<string, Store> _cache = new ConcurrentDictionary<string, Store>();
    public async Task<Store> GetStoreByUsernameAsync(string username)
    {	
    	Store value;
        // get the semaphore specific to this username
    	var keyLock = _keyLocks.GetOrAdd(username, x => new SemaphoreSlim(1));
      	await keyLock.WaitAsync().ConfigureAwait(false);
    	try
    	{
    		// try to get Store from cache
    		if (!_cache.TryGetValue(username, out value))
    		{
    			// if value isn't cached, get it from the DB asynchronously
    			value = await _storeRepository.GetSingleAsync(x => x.UserName == username).ConfigureAwait(false);
    	
    			// cache value
    			_cache.TryAdd(username, value);
    		}
    	}
    	finally
    	{
    		keyLock.Release();
    	}
    	return value;
    }
