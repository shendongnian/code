    public class EnforceTrueAttribute : ValidationAttribute, IClientValidatable
        {
            public override bool IsValid(object value)
            {
                if (value == null) return false;
                if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");
                return (bool)value == true;
            }
    
            public override string FormatErrorMessage(string name)
            {
                return "The " + name + " field must be checked in order to continue.";
            }
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                yield return new ModelClientValidationRule
                {
                    ErrorMessage = String.IsNullOrEmpty(ErrorMessage) ? FormatErrorMessage(metadata.DisplayName) : ErrorMessage,
                    ValidationType = "enforcetrue"
                };
            }
        }
