    public string ReadProperty(object object1)
    {
    	var object2Property = object1.GetType().GetProperties().FirstOrDefault(x => x.Name == "Object2");
    	if (object2Property != null)
    	{
    		var anyProperty = object2Property.GetType().GetProperties().FirstOrDefault(x => x.Name == "Property");
    		if (anyProperty != null)
    		{
    			var object2Value = object2Property.GetValue(object1, null);
    
    			if (object2Value != null)
    			{
    				var valueProperty = anyProperty.GetValue(object2Value, null);
    
    				return valueProperty;
    			}
    		}
    	}
    
    	return null;
    }
