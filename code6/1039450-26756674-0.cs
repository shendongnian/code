    private void AddAttributes(object attributes)
    {
        foreach(var property in attributes.GetType().GetProperties())
    	{
    		GridAttributes.Add(
    			property.Name, 
    			property.GetValue(attributes));
    	}
    }
