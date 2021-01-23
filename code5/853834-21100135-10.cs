    public enum ActionMethodEnum
    	{
    		Change,
    		Update
    	}
    
    	public class ConditionalRequiredAttribute : RequiredAttribute
    	{
    		public ActionMethodEnum ActionMethodEnum { get; set; }
    
    		public string ActionMethodFieldName { get; set; }
    
    		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    		{
    			var property = validationContext.ObjectType.GetProperty(ActionMethodFieldName);
    			if (property == null)
    			{
    				return new ValidationResult(string.Format("{0} is unknown property", ActionMethodFieldName));
    			}
    			if (property.PropertyType != typeof(ActionMethodEnum))
    			{
    				return new ValidationResult(string.Format("{0} property has invalid type", ActionMethodFieldName));
    			}
    
    			ActionMethodEnum actionMethodEnum;
    			Enum.TryParse(property.GetValue(validationContext.ObjectInstance, null).ToString(), out actionMethodEnum);
    			if (actionMethodEnum != ActionMethodEnum)
    			{
    				return ValidationResult.Success;
    			}
    
    			return base.IsValid(value, validationContext);
    		}
    	}
