    public class ValidateMinDateAttribute : ValidationAttribute
    {
      private String Property { get; set; }
    
      public ValidateMinDateAttribute(String property)
      {
        Property = property;
      }
    
      protected override ValidationResult IsValid(object value, ValidationContext context)
      {
        Object instance = context.ObjectInstance;
        Type type = instance.GetType();
        Object propertyValue = type.GetProperty(Property).GetValue(instance, null);
        if (propertyValue < value or something else)//perform your check based on the value of the property, do conversion if you need
        {
          ValidationResult result = base.IsValid(value, context);
          return result;
        }
        return ValidationResult.Success;
      }
    }
