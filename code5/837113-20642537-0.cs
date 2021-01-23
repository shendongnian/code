    public class RequireWhenCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (EmployeeModel) validationContext.ObjectInstance;
            if (employee.CategoryId == 1)
            {
                return ValidationResult.Success;
            }
            var emailStr = value as String;
            return string.IsNullOrEmpty(emailStr) ? new ValidationResult("Value is required.") : ValidationResult.Success;
        }
    }
    public sealed class EmployeeModel
    {
        [Required]
        public int CategoryId { get; set; }
        [RequireWhenCategory]
        public string Email { get; set; } // If CategoryId == 1 then it is required
    }
