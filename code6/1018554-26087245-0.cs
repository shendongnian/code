    var enumerableTInterface = propertyType
        .GetInterfaces()
        .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition()
                                                == typeof(IEnumerable<>));
    bool isStronglyTypedCollection = enumerableTInterface != null;
    if (isStronglyTypedCollection)
    {
        var elementType = enumerableTInterface.GetGenericArguments()[0];
        //...
