    public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
    {
        TValue local;
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (valueFactory == null)
        {
            throw new ArgumentNullException("valueFactory");
        }
        if (!this.TryGetValue(key, out local))
        {
            this.TryAddInternal(key, valueFactory(key), false, true, out local);
        }
        return local;
    }
 
