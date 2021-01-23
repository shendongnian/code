    myMemoryCache.Set("key", null, new CacheItemPolicy() {RemovedCallback = new CacheEntryRemovedCallback(CacheRemovedCallback) /* your other parameters here */});
    
    public void CacheRemovedCallback(CacheEntryRemovedArguments arguments)
    {
        // do what's needed
    }
