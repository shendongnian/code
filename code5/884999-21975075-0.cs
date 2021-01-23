    //Still used for the no parameter constructor checking.
    public void CreateInstance<T>(string id) where T : class, new()
    {
        lock (_syncroot)
        {
            _internal_dict.Add(id, new T());
        }
    }
    public void CreateInstance<T>(string id, params object[] args) where T : class
    {
        lock (_syncroot)
        {
            _internal_dict.Add(id, Activator.CreateInstance(typeof(T), args));
        }
    }
