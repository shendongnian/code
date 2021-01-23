    public void UnionWith(IEnumerable<T> other)
    {
        ...
        foreach (T item in other) 
        {
             AddIfNotPresent(item);
        }
    }
