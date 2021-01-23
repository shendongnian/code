    foreach(MyClass obj in lstSource)
    {
        foreach(string propertyName in wantedProperties)
        {
    		PropertyInfo property = typeof(MyClass).GetProperty(propertyName);
    
    		object value = property.GetValue(obj);
    		Type propertyType = property.PropertyType;
    	}
    }
