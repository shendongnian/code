    public static void InitializeAllProperties<T>(this T obj)
    {
        Type type = typeof(T);
        var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
        foreach (var prop in type.GetProperties(flags))
            if (!prop.GetIndexParameters().Any())
                prop.GetValue(obj);
    }
