    public static readonly ObjectCache cache = MemoryCache.Default; // this would be an instance variable
    public void AddToCache<T>(string key, T item)
        {
            cache.Add(key, item, DateTime.Now.AddMinutes(CACHE_TIMEOUT));
        }
    public T GetFromCache<T>(string key) where T : class
        {
            try
            {
                return (T)cache[key];
            }
            catch
            {
                return null;
            }
        }
