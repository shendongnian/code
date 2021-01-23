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
                p.SetValue(destination, kv.Value, null);
            }
            else
            {
                FieldInfo f;
                if (FieldMap.TryGetValue(kv.Key.ToLower(), out f))
                {
                    f.SetValue(destination, kv.Value);
                }
            }
        }
    }
