    static void SetDtoFields<T>(object targetDto, IEnumerable<T> fields)
    {
        Type fieldType = typeof(T);
        var fieldNameProp = fieldType.GetProperty("ShortDescript");
        if (fieldNameProp == null || !fieldNameProp.CanRead) 
            return;
        var dataValProp = fieldType.GetProperty("DataValue");
        if (dataValProp == null || !dataValProp.CanRead) 
            return;
        Type targetType = targetDto.GetType();
        foreach (T field in fields)
        {
            var propToSet = targetType.GetProperty((string)fieldNameProp.GetValue(field),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase );
            if (propToSet != null && propToSet.CanWrite &&
                propToSet.PropertyType.IsAssignableFrom(dataValProp.PropertyType))
            {
                propToSet.SetValue(targetDto, dataValProp.GetValue(field));
            }
        }
    }
