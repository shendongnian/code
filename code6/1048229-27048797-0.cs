    public object this[string key]
    {
        get
        {
            object value;
            if (TryGetValue(key, out value))
            {
                _initialKeys.Remove(key);
                return value;
            }
            return null;
        }
        set
        {
            _data[key] = value;
            _initialKeys.Add(key);
        }
    }
