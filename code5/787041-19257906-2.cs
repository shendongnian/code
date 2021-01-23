    public static object Get(DataCache dataCache, string label, object typeObject)
    {
        try
        {
            Type type = typeObject.GetType();
            object value = dataCache.Get(label);
            if (value != null && type.IsAssignableFrom(value.GetType()))
                return value;
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
