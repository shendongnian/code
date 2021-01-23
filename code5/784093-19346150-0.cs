    // Cache client configured by settings in application configuration file.
    DataCacheFactoryConfiguration config = new DataCacheFactoryConfiguration("mycache.cache.windows.net");
    DataCacheFactory cacheFactory = new DataCacheFactory(config);
    DataCache defaultCache = cacheFactory.GetDefaultCache();    
    
    // Put and retrieve a test object from the default cache.
    defaultCache.Put("testkey", "testobject");
    string strObject = (string)defaultCache.Get("testkey");
