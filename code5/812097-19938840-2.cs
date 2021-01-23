    string fieldProperty = "ArrayField1";
    System.Reflection.PropertyInfo pi = baseClass.GetType().GetProperty(fieldProperty);
    if (pi.PropertyType.IsArray)
    {
        Type elementType = pi.PropertyType.GetElementType();
        System.Reflection.PropertyInfo pi2 = elementType.GetProperty("Color");
    }
