    HashSet<String> properties = new HashSet<String>();
    // add the properties 
    foreach (var propertyInfo in MyObject.GetType().GetProperties())
    {
        if (propertyInfo.CanRead)
        {
            if (properties.Contains(propertyInfo.Name))
            {
                propertyInfo.SetValue(MyObject, "Some value", null);
            }
        }
    }
