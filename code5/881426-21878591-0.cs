    var type = myVariable.GetType();
    foreach (var i in type.GetInterfaces())
    {
        if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            return i.GetGenericTypeArguments()[0];
        }
    }
    // not a generic collection
    return typeof(object);
