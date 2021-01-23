    static bool IsGeneric(Type type)
    {
        while (type != null)
        {
            if (type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(Generic<>))
            {
                return true;
            }
            type = type.BaseType;
        }
        return false;
    } 
