    public class MinCustomLengthAttribute : ValidationAttribute, IClientValidatable
    {
        private String PropertyName { get; set; }
        
        public MinCustomLengthAttribute(String propertyName, String errormessage)
        {     
           this.PropertyName = propertyName;
           this.ErrorMessage = errormessage;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
           // Just for test server side validation always returns Success
           return ValidationResult.Success;
        }
    
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
           var modelClientValidationRule = new ModelClientValidationRule
           {
              ValidationType = "mincustomlength",
              ErrorMessage = this.ErrorMessage
           };
           modelClientValidationRule.ValidationParameters.Add("prop", PropertyName);
           yield return modelClientValidationRule;
        }
    }
