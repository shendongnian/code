    public class MyCustomAttribute : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
         {
            //Your logic here.
            return ValidationResult.Success;
         }
    }
