    public static IEnumerable<Object> Pluck<T>(this IEnumerable<T> source, string, propName)
    {
        var prop = typeof(T).GetProperty(propName);
        return prop == null
             ? Enumerable.Empty<Object>()
             : source.Select(x => prop.GetValue(x));
    };
