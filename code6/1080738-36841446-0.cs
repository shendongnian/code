    [AttributeUsage(AttributeTargets.Class)]
    public class ExactlyOneRequiredAttribute : ValidationAttribute
    {
        public string FirstPropertyName { get; set; }
        public string SecondPropertyName { get; set; }
        //Constructor to take in the property names that are supposed to be checked
        public ExactlyOneRequiredAttribute(string firstPropertyName, string secondPropertyName)
        {
            FirstPropertyName = firstPropertyName;
            SecondPropertyName = secondPropertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) 
               return new ValidationResult("Object must have a value;");
            var neededProperties = validationContext.ObjectType.GetProperties().Where(propertyInfo => propertyInfo.Name == FirstPropertyName || propertyInfo.Name == SecondPropertyName).Take(2).ToArray();
            var value1 = neededProperties[0].GetValue(value);
            var value2 = neededProperties[1].GetValue(value);
            if (value1 == null | value2 == null)
                return ValidationResult.Success;
            return FailedValidationResult();
        }
        public override string FormatErrorMessage(string name) => $"One of the fields: '{FirstPropertyName} or {SecondPropertyName}' is required, it is not allowed to set both.";
        private ValidationResult FailedValidationResult() => new ValidationResult(FormatErrorMessage(FirstPropertyName), new List<string> {FirstPropertyName, SecondPropertyName});
    }
