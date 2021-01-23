    public class RequiredIf : ValidationAttribute, IClientValidatable
    {
        private string _checkPropertyName;
        public RequiredIf(string checkPropertyName)
        {
            _checkPropertyName = checkPropertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Get PropertyInfo object
            var phonePropertyInfo = validationContext.ObjectType.GetProperty(_checkPropertyName);
            //Get value from property
            bool checkValue = (bool)phonePropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if(!checkValue)
               return new ValidationResult(this.ErrorMessageString);
            return null;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = this.ErrorMessageString;
            rule.ValidationType = "requiredIf";
            rule.ValidationParameters.Add("checkpropertinputname", _checkPropertyName);
            yield return rule;
        }
    }
