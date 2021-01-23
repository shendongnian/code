    public static object Get<T>(DataCache dataCache, string label)
    {
        try
        {
            object value = dataCache.Get(label);
            if (value is T)
                return (T)value;
            else
            {
                dataCache.Remove(label);
                return null;
            }
        }
        catch (DataCacheException)
        {
            dataCache.Remove(label);
            return null;
        }
    }
