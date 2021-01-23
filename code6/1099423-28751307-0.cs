    var properties = instance.GetType().GetProperties();
    foreach(var property in properties)
    {
    	var propertyType = property.PropertyType;
    	
        if(propertyType == typeof(string))
        {
            property.SetValue(instance, "A String");
        }
        else if(propertyType == typeof(int))
        {
            property.SetValue(instance, 42);
        }
        // and so on for the different types
    }
