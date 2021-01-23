    public static bool AddItemToCache<T>(string key, Dictionary<string, T> cacheItem, TimeSpan ts)
    {
        if (!IsCached(key))
        {
            System.Web.HttpRuntime.Cache.Insert(key, cacheItem, null, Cache.NoAbsoluteExpiration, ts);
    
            return IsCached(key);
        }
    
        return true;
    }
