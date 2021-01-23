    T UnProxy<T>(T efObject) where T : new()
    {
        var type = efObject.GetType();
        if (type.Namespace == "Castle.Proxies")
        {
            var baseType = type.BaseType;
            var returnObject = new T();
            foreach (var property in baseType.GetProperties())
            {
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                if (propertyType.Namespace == "System")
                {
                    var value = property.GetValue(efObject);
                    property.SetValue(returnObject, value);
                }
            }
            return returnObject;
        }
        return efObject;
    }
