    public class CacheHandler : ICacheHandler
    {
    
    private IRequester Requester;
    private ICache Cache;
    private object syncLock = new object();
    
    public CacheHandler()
    {
        Requester = new RequesterHttp();
        Cache = new CacheDB();
    }
    public T Get<T>(string path)
    {
        lock(syncLock)
        {
            // Get data from cache
            var cacheRes = Cache.Get(path);
            // If not null, deserialize to object and compare if its time to update from third party or to return cached version
            if (cacheRes != null)
            {
                // Deserialize xml from db
                Response<T> deserialized = Xml.Deserialize<Response<T>>(cacheRes);
                // Compare xml from db cached untill with current time 
                int compare = DateTime.Compare(DateTime.UtcNow, deserialized.CachedUntil);
                // If cacheduntill is later than current time, return cached info
                if (compare <= 0)
                    return deserialized.Result;
            }
            // If no cache, or its time to update current cache - Get third party xml
            var reqRes = Requester.Get(path);
            // Save it to cache
            Cache.Set(path, reqRes);
            // Desearialize
            Response<T> deserialized2 = Xml.Deserialize<Response<T>>(reqRes);
            // Return it to user
            return deserialized2.Result;
        }
    }
    }
