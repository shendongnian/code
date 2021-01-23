    Type myType = Type.GetType(className);
    var instance = System.Activator.CreateInstance(myType);
    PropertyInfo[] properties = myType.GetProperties();
    
    foreach (var property in properties)
    {
        if (property.CanWrite) 
        {
            property.SetValue(instance, session[property.Name], null);
        }
    }
