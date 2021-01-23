    private void DynamicallyAccessPropertyOnObject<T,K>(this T propertyToAccess, K targetObj)
    {
        var targetType = targetObj.GetType();
        var property = targetType.GetProperties()
                      .FirstOrDefault(x => x.GetType() == typeof(T));
        
    }
