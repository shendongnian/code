    private static void DynamicallyAccessPropertyOnObject<T>()
    {
        var customClass = typeof(CustomClass);
        var property = customClass
                      .GetProperties()
                      .FirstOrDefault(x => x.GetType() == typeof(T));
        
    }
