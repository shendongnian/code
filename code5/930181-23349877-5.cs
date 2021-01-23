    private static void DynamicallyAccessPropertyOnObject<T, K>(
            K targetObj)
    {
        var targetType = targetObj.GetType();
        var property = targetType
                      .GetProperties()
                      .FirstOrDefault(x => x.GetType() == typeof(T));
        if(property != null) 
        {
           var value = property.GetValue(targetObj);
        }
    }
