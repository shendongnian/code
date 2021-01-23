    lock (cacheLock)
    {
        if(cacheFactory == null)
        {
            DataCacheFactoryConfiguration config = new DataCacheFactoryConfiguration(...); 
            cacheFactory = new DataCacheFactory(config);
        }
        return cacheFactory;
    }
