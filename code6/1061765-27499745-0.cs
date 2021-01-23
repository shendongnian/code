    public class SomeCustomValidator : ValidationAttribute
    {
       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
       {
          string number = value as string;
          if (value == null) return new ValidationResult("Name must have a valid value"));
          if (!value.IsEmpty && value.Length <= 20)
          {
              return ValidationResult.Success;
          }
          return new ValidationResult("Name must be a non-empty string smaller than 20 chars"));
       }
    }
