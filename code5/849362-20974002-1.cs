    if (type.IsGenericType
        && type.GetGenericTypeDefinition() == typeof(Nullable<>)
        && type.GetGenericArguments().Any(t => t.IsValueType && t.IsPrimitive))
    {
        // it's a nullable primitive
    }
