    public static T Create<T>() where T : ICreateEmptyInstance, new()
    {
        return (T) Create(typeof (T));
    }
    
    private static object Create(Type type)
    {
        var instance = Activator.CreateInstance(type);
    
        var properties = type.GetProperties();
        foreach (var property in properties.Where(property => typeof(ICreateEmptyInstance).IsAssignableFrom(property.PropertyType)))
        {
            var propertyInstance = NullObject.Create(type);
            property.SetValue(instance, propertyInstance);
        }
    
        return instance;
    }
