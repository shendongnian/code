    public T Get<T>(int index)
    {
        Type type = typeof(T);
        Array array;
        if (_values.TryGetValue(type, out array))
        {
            if (index >= 0 && index < array.Length)
            {
                return (T)array.GetValue(index);
            }
        }
        return default(T);
    }
