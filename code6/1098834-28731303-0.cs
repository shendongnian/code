    public static MethodInfo GetRuntimeMethodEx(
            this Type type, string name, params Type[] types)
    {
        var withMathingParamTypes =
            from m in type.GetRuntimeMethods()
            where m.Name == name
            let parameterTypes = m.GetParameters().Select(p => p.ParameterType).ToArray()
            where parameterTypes.Length == types.Length
            let pairs = parameterTypes.Zip(types, (actual, expected) => new {actual, expected})
            where pairs.All(x => TypesMatch(x.actual, x.expected))
            select m;
        return withMathingParamTypes.FirstOrDefault();
    }
    private static bool TypesMatch(Type actual, Type expected)
    {
        if (actual == expected)
            return true;
        if (actual.IsGenericType && expected.IsGenericTypeDefinition)
            return actual.GetGenericTypeDefinition() == expected;
        return false;
    }
