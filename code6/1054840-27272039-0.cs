    MemoryCache cache = MemoryCache.Default;
    string cacheName = "mycachename";
    
    if cache.Contains(cacheName) == false || cache[cacheName] == null)
    {
        // load data
        var data = await response.Content.ReadAsAsync<T>();
        // save data to cache
        cache.Set(cacheName, data, new CacheItemPolicy() { SlidingExpiration = DateTime.Now.AddDays(1).TimeOfDay });
    }
    
    return cache[cacheName];
