    public class PeanutOrderAttribute : ValidationAttribute, IClientValidatable
    {
    	private readonly string _peanutsProperty;
    	private readonly string _orderTypeProperty;
    	
    	public PeanutOrderAttribute(string peanutsPropertyName, string orderTypePropertyName)
    	{
    		_peanutsProperty = peanutsPropertyName;
    		_orderTypeProperty = orderTypePropertyName;
    	}
    	
    	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    	{
    		// get target property and value
    		var peanutInfo = validationContext.ObjectType.GetProperty(this._peanutsProperty);
    		var peanutValue = peanutInfo.GetValue(validationContext.ObjectInstance, null);
    
    		// get compare property and value
    		var ordertypeInfo = validationContext.ObjectType.GetProperty(this._orderTypeProperty);
    		var ordertypeValue = ordertypeInfo.GetValue(validationContext.ObjectInstance, null);
    		
    		// if validation does not pass
    		if (ordertypeValue == "Peanuts" && peanutValue < 1){
    			 return new ValidationResult("Error Message");
    		}
    		
    		// else return success
    		return ValidationResult.Success;
    	}
    	
    	public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    	{
    		var rule = new ModelClientValidationRule
    		{
    			ErrorMessage = this.ErrorMessageString,
    			ValidationType = "PeanutOrder"
    		};
    
    		rule.ValidationParameters["peanuts"] = this._peanutsProperty;
    		rule.ValidationParameters["ordertype"] = this._orderTypeProperty;
    		
    		yield return rule;
    	}
    }
