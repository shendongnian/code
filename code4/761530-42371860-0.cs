    public PropertyDescriptorCollection GetProperties()
    {
    	if (propertyCache == null)
    	{
    		propertyCache = new PropertyDescriptorCollection(someProperties.ToArray<PropertyDescriptor>());
    	}
    
    	return propertyCache;
    }
