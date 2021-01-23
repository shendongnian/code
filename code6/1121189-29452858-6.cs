    public static object Cast<TBase>(this IEnumerable<TBase> original, Type type)
    {
        return typeof(Enumerable)
            .GetMethod("Cast", BindingFlags.Static | BindingFlags.Public)
            .MakeGenericMethod(type)
            .Invoke(null, new object[] { original });
    }
