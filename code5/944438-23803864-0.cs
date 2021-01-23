    public class CONT_RU06Attribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int value = int.Parse(value.ToString());
    
                if (value < 2 || value > 6)                
                    return new ValidationResult("Value must be between 2 and 6");
            }
    
            return ValidationResult.Success;
        }
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());           
            rule.ValidationType = "range";
            yield return rule;
        }
    }
