    if (cache == null)
    {
        if(factory == null)
            factory = new DataCacheFactory();
 
        if(string.IsNullOrWhiteSpace(cacheName))
            cacheName = ConfigurationManager.AppSettings["APP_FABRIC_CACHE_NAME"];
 
        cache = factory.GetCache(cacheName);
        return cache;
    }
