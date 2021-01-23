    private TEntity GetFromCache<TEntity>(string key, Func<TEntity> valueFactory) where TEntity : class 
    {
        ObjectCache cache = MemoryCache.Default;
        // the lazy class provides lazy initializtion which will eavaluate the valueFactory expression only if the item does not exist in cache
        var newValue = new Lazy<TEntity>(valueFactory);            
        CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) };
        //The line below returns existing item or adds the new value if it doesn't exist
        var value = cache.AddOrGetExisting(key, newValue, policy) as Lazy<TEntity>;
        return (value ?? newValue).Value; // Lazy<T> handles the locking itself
    }
