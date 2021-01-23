        public class CustomValidation : ValidationAttribute
        {
              public CustomValidation(string otherproperty)
              : base("Your Error Message goes here")
              {
                  OtherProperty = otherproperty;
              }
              public string OtherProperty { get; set; }
              public override string FormatErrorMessage(string name)
              {
                   return string.Format(ErrorMessageString, name, OtherProperty);
              }
              protected override ValidationResult IsValid(object firstobject, ValidationContext validationContext)
              {
                    var firstValue = firstobject;
                    var secondValue = GetSecondObject(validationContext);
              if(firstValue !=null && secondValue!=null)
              {
                    if (//Your Condition for validation failure)
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }               
              }
                    return ValidationResult.Success;
              }
             protected object GetSecondObject(
    ValidationContext validationContext)
             {
                    var propertyInfo = validationContext
                                  .ObjectType
                                  .GetProperty(OtherProperty);
                   if (propertyInfo != null)
                   {
                        var secondValue = propertyInfo.GetValue(
                        validationContext.ObjectInstance, null);
                        return secondValue as object;
                   }
                  return null;
            }
      }
