    if (type.IsGenericType)
    {
        Type[] genericArguments = type.GetGenericArguments();
        if (genericArguments.Length == 1)
        {
            Type proposedEnumerable = typeof(IEnumerable<>).MakeGenericType(genericArguments);
            if (proposedEnumerable.IsAssignableFrom(type))
            {
