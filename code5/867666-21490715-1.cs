    public delegate bool CheckAgainstDataDelegate(object newValue, string fieldName);
    public class CustomValidationRule : ValidationRule
    {
    
        public CheckAgainstDataDelegate Validator { get; set; }
    
        public override ValidationResult Validate(object value, CultureInfo cultureInfo, BindingGroup owner)
        {
            return Validate((object)owner, cultureInfo);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo, BindingExpressionBase owner)
        {
            switch (ValidationStep)
            {
                case ValidationStep.UpdatedValue:
                case ValidationStep.CommittedValue:
                    value = (object)owner;
                    break;
            }
            return new ValidationResult(Validator(value, ((BindingExpression) owner).ResolvedSourcePropertyName), null);
        }
    
        [Obsolete("Use Validator property of type delegate instead to validate the data",true)]
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) { return null; } //not used anymore
    }
