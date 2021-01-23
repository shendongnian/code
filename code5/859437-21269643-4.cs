    const string CacheKey = "CacheKey";
    static readonly object cacheLock = new object();
    private static string GetCachedData()
    {
        //Returns null if the string does not exist, prevents a race condition where the cache invalidates between the contains check and the retreival.
        var cachedString = MemoryCache.Default.Get(CacheKey, null) as string;
        if (cachedString != null)
        {
            return cachedString;
        }
        lock (cacheLock)
        {
            //Check to see if anyone wrote to the cache while we where waiting our turn to write the new value.
            cachedString = MemoryCache.Default.Get(CacheKey, null) as string;
            if (cachedString != null)
            {
                return cachedString;
            }
            //The value still did not exist so we now write it in to the cache.
            CacheItemPolicy cip = new CacheItemPolicy()
                                  {
                                      AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(20))
                                  };
            var expensiveString = SomeHeavyAndExpensiveCalculation();
            MemoryCache.Default.Set(CacheKey, expensiveString, cip);
            return expensiveString;
        }
    }
