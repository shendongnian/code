    ....
    if (type.IsGenericType)
    {
        Type genericType = type.GetGenericTypeDefinition();
        name = genericType.FullName;
    }
    ....
