    public PropertyInfo GetProperty<T>(){
        var allProperties = TypeOf(MyEntities).GetProperties();
        return allProperties.FirstOrDefault(prop => prop.PropertyType.IsGenericType
            && prop.PropertyType.GenericTypeArguments.FirstOrDefault() == typeof(T));
    }
