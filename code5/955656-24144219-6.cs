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
    			       var rangeAtt = (RangeAttribute)att;
    			       int intVal = (int)prop.GetValue(ob);
                               
                        if (rangeAtt.Min > intVal || rangeAtt.Max < intVal)
                                  return new FieldValitaionResult("Field {0} must be between {1} and {2}, prop.Name, rangeAtt.Min, rangeAtt.Max);
                               return null;
    			}
    		}
    	}
    }
