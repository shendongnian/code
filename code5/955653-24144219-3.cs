    class Validator
    {
    	public IEnumerable<FieldValidationResult> ValidateObject(object ob)
    	{
    		List<FieldValidationResult> list = new List<FieldValidationResult>();
    
    		var properties = ob.GetType().GetProperties();
    
    		foreach(var property in properties)
    		{
    			var res = ValidateField(ob, property);
    
    			list.Add(res);
    		}
    
    		return list;
    	}
    
    	private FieldValidationResult ValidateField(object ob, PropertyInfo prop)
    	{
    		var attributes = prop.GetCustomAttributes();
    
    		foreach(var att in attributes)
    		{
    			if (att is StringNotNullOrEmptyAttribute)
    			{
    				string strVal = prop.GetValue(ob) as string;
    
    				if (string.IsNullOrEmpty(strVal))
    					return new FieldValidationResult("Field {0} can not be empty")
    
    				return null;
    			}
    
    			if (att is RangeAttribute)
    			{
    				// validate range attribute
    			}
    		}
    	}
    }
