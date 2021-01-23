    void SetDict<T>(T value)
    {
        Type t = typeof(T);
        if (dictionaries[t.FullName] == null)
        {
            dictionaries[t.FullName] = new Dictionary<string,T>();
        }
    }
