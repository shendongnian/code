    class ValidationTest : ValidationRule
    {
        private int result;
        private bool hadValue = false;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (hadValue  && (value == null || string.IsNullOrEmpty(value.ToString())))
            {
                return new ValidationResult(false, "Value cannot be empty.");
            }
            if (value.ToString().Length > 4)
            {
                hadValue = true;
                return new ValidationResult(false, "Name cannot be more than 20 characters long.");
            }
            hadValue = true;
            return ValidationResult.ValidResult;
        }
    }
