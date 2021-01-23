    public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
    {
        TValue local2;
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (updateValueFactory == null)
        {
            throw new ArgumentNullException("updateValueFactory");
        }
        do
        {
            TValue local3;
            while (this.TryGetValue(key, out local3))
            {
                TValue newValue = updateValueFactory(key, local3);
                if (this.TryUpdate(key, newValue, local3))
                {
                    return newValue;
                }
            }
        }
        while (!this.TryAddInternal(key, addValue, false, true, out local2));
        return local2;
    }
