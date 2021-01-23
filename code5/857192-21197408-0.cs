    static Type GetListType(IEnumerable enumerable)
    {
        var type = enumerable.GetType();
        var enumerableType = type
            .GetInterfaces()
            .Where(x => x.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .First();
        return enumerableType.GetGenericArguments()[0];
    }
 
