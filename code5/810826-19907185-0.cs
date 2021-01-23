    public class LargerThanAttribute: ValidationAttribute, IClientValidatable
    {
         private string _listPropertyName { get; set; }
         
         public LargerThanAttribute(string listPropertyName)
         {
             this._listPropertyName = listPropertyName;
         }
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
         {
            if(value == null)
                return new ValidationResult("Not a valid value");
            var listProperty = validationContext.ObjectInstance.GetType().GetProperty(_listPropertyName);
            double propValue = Convert.ToDouble(listProperty.GetValue(validationContext.ObjectInstance, null));
            if(propValue <= Convert.ToDouble(value))
                return ValidationResult.Success;
            return new ValidationResult("End value is smaller than start value");
        }
    }
