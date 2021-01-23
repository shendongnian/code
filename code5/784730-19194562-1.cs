    private static Type GetElementType(Type type)
    {
        Type enumerableType = type.GetInterfaces().FirstOrDefault(IsGenericEnumerable);
        if (enumerableType != null)
        {
            Type[] genericArguments = enumerableType.GetGenericArguments();
            return genericArguments[0];
        }
        // return 'object' for a non-generic IEnumerable
        return typeof(IEnumerable).IsAssignableFrom(type) ? typeof(object) : type;
    }
    private static bool IsGenericEnumerable(Type type)
    {
        return type.IsGenericType &&
               type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
    }
