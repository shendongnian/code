    public bool Exists<T>(string key) where T : class
    {
        Type type = typeof(T);
        lock (_sync)
        {
            return _cache.ContainsKey(Tuple.Create(type, key));
        }
    }
