    static bool IsDataAccessLayer(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DataAccessLayerBase<>)
            || type.BaseType != null && IsDataAccessLayer(type.BaseType));
    }
