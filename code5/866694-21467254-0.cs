    public class CheckInputDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputDate = (DateTime)value;
            var compareDate = DateTime.Now.AddDays(-21);
            int result = DateTime.Compare(inputDate, compareDate);
            const string sErrorMessage = "Input date must be within 3 weeks.";
            if (result < 0)
            {
                return new ValidationResult(sErrorMessage); 
            }
            return ValidationResult.Success;
        }
    }
