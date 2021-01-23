    public class CustomAttribute : ValidationAttribute
    {    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // validation logic
        }
    }
