    public Cache.CacheEntry Get(string key, bool updateAccessed)
    {
        var cacheKey = GetCacheableKey(key);    
    
        var conn = RedisConnectionGateway.Current.GetConnection();
        
        var entry = conn.Get<Cache.CacheEntry>(cacheKey);
        return entry;        
    }
    public override void Add(string key, Cache.CacheEntry entry)
    {
        var cacheKey = GetCacheableKey(key);    
    
        var conn = RedisConnectionGateway.Current.GetConnection();
        
        using (var trans = conn.CreateTransaction())
        {
            trans.Set(cacheKey, entry);
            trans.Strings.Increment(DbNum, CacheEntryCountKey);
            trans.Strings.Increment(DbNum, CacheSizeKey, entry.DataLength);
            trans.Sets.Add(DbNum, CacheKeysKey, cacheKey);
            trans.Execute();
        }        
    }
