    public static class CustomValidations
    {
        public static ValidationResult ValidatePassword(string password)
        {
            // Implement validation logic here, e.g. require numbers,
            // uppercase etc. and create localized ValidationResult.
            return new ValidationResult(Resources.PasswordValidation.NoNumbers);
        }
    }
