    namespace MVCApplication
        {   
        
            public class ValidateDateRange: ValidationAttribute
            {
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {                 
        // your validation logic
                    if (value >= "01/10/2008" && value <= "01/12/2008" )
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Date is not in given range.");
                    }
                }
            }
        }
