    private static void DynamicallyAccessPropertyOnObject<T, K>(K targetObj)
    {
        var targetType = targetObj.GetType();
        var property = targetType
                      .GetProperties()
                      .FirstOrDefault(x => x.PropertyType == typeof(T));
        if(property != null) 
        {
           var value = (T)property.GetValue(targetObj);
        }
    }
