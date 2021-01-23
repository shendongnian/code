    if (propertyInfo.GetMethod.IsPublic)
    {
    
        var value = propertyInfo.GetMethod.Invoke(Instance, null);
    }
