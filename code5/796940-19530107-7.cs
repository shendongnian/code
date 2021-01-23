    public static void Map(ExpandoObject source, T destination)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (destination == null)
            throw new ArgumentNullException("destination");
    
        foreach (var kv in source)
        {
            PropertyInfo p;
            if (PropertyMap.TryGetValue(kv.Key.ToLower(), out p))
            {
                MergeProperty(p, source, destination);
            }
            else
            {
                // do similar merge for fields
            }
        }
    }
