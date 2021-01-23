    if (aProperty.PropertyType.IsGenericType &&
        aProperty.GetGenericTypeDefinition() == typeof(MyGenericProperty<>))
    {
        var value = (MyGenericProperty) aProperty.GetValue(sourceObject, null);
        // Use value
    }
