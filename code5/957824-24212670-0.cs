    private ConcurrentDictionary<object, object> dictionary;
    public void StoreVal<T>(T val)
    {
        dictionary.GetOrAdd(val, _ => ComputeRandomValue());
    }
