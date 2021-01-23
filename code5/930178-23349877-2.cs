    private static void DynamicallyAccessPropertyOnObject<T>(this T propertyToAccess)
    {
        var customClass = typeof(CustomClass);
        var property = customClass
                      .GetProperties()
                      .FirstOrDefault(x => x.GetType() == typeof(T));
        
    }
