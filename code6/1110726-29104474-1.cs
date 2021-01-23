    public static IEnumerable<Type> BaseTypes(this Type type)
    {
        if (type == null) throw new ArgumentNullException("type");
        Type baseType = type;
        while(true)
        {
            baseType = baseType.BaseType;
            if (baseType == null) 
                break;
            yield return baseType;
        }
    }
