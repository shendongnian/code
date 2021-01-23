    foreach (var propertyInfo in typeof (Foo).GetProperties())
    {
        if (propertyInfo.PropertyType.IsGenericType)
        {
            var isAList = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof (List<>);
            var isGenericOfTypeBar = propertyInfo.PropertyType.GetGenericArguments()[0] == typeof(Bar);
        }
    }
