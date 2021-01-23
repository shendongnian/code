    public DbContext GetDbContext<T>() where T : new()
    {
        if (typeof(T).BaseType != typeof(DbContext))
            throw new ArgumentException("Type is not a DbContext type");
        if (!_contexts.ContainsKey(type))
            _contexts.Add(typeof(T), new T());
        return _contexts[type];
    }
