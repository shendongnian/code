    public static bool TestIfSequenceOfEnum(Type type)
    {
        return (type.IsInterface ? new[] { type } : type.GetInterfaces())
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .Any(i => i.GetGenericArguments().First().IsEnum);
    }
