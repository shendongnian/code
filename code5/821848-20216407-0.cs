    private static readonly ObjectCache cache = MemoryCache.Default;
    // add to cache
    AddToCache<string>(username, value);
    // get from cache
     
     string value = GetFromCache<string>(username);
     if (value != null)
     {
         // got item, do something with it.
     }
     else
     {
        // item does not exist in cache.
     }
    public void AddToCache<T>(string token, T item)
        {
            cache.Add(token, item, DateTime.Now.AddMinutes(1));
        }
    public T GetFromCache<T>(string cacheKey) where T : class
        {
            try
            {
                return (T)cache[cacheKey];
            }
            catch
            {
                return null;
            }
        }
