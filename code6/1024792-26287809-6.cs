    public class SomeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, 
          CultureInfo cultureInfo)
        {
            var userText = value as string;
            return String.IsNullOrWhiteSpace(userText) ? 
                new ValidationResult(false, "Value must be provided.") : 
                new ValidationResult(true, null);
        }
    }
