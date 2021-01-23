        namespace MVCApplication
            {   
        
                public class ValidateDateRange: ValidationAttribute
                {
                  public DateTime FirstDate { get; set; }
                  public DateTime SecondDate { get; set; }
    
                    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                    {                 
                        // your validation logic
                        if (value >= FirstDate && value <= SecondDate)
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
