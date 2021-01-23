    private static T GetCachedCollection<T>(Guid cacheKey, Lazy<T> initializer)
    {
        var cachedValue = (Lazy<T>)(MemoryCache.Default.AddOrGetExisting(
            cacheKey.ToString(), initializer, _policy) ?? initializer);
        return cachedValue.Value;
    }
