    private static Type GetElementType(Type type)
    {
        if (_visitedTypes.ContainsKey(type))
        {
            return type;
        }
        
        ...
    }
