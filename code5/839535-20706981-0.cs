    public static object[] StripPropertyValues<T>(T obj)
    {
        return typeof(T).GetProperties(BindingFlags.Public |
            BindingFlags.Instance)
                .Select(prop => prop.GetValue(obj))
                .ToArray();
    }
