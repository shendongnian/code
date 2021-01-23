    static Type[] BaseTypesAndInterfaces(Type type) 
    {
        var lst = new List<Type>(type.GetInterfaces());
        while (type.BaseType != null) 
        {
            lst.Add(type.BaseType);
            type = type.BaseType;
        }
        return lst.ToArray();
    }
