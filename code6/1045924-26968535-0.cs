    public T GetObjectFromMemoryCacheWithDefParams<T>(string key, Func<string,T> defGetValueFunc) where T : class
    {
      var result = _cache.Get(key) as T;    
      return result ?? defGetValueFunc(*somestring*);
    }
    
    
    var result = CacheService.GetObjectFromMemoryCacheWithDefParams<IEnumerable<dynamic>>(casheName, getLpVideos(lng)  );
