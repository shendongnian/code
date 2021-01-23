    public class ValidAmount : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] memberNames = { "Amount" };
            var amountProperty = validationContext.ObjectType.GetProperty("Amount");
            double amountValue = (double)amountProperty.GetValue(validationContext.ObjectInstance, null);
            // at this stage you have "amount value"
            // here you are verifying whether amount is less than 1
            if (amountValue<1)
            {
                // here you return your custom error message
                return new ValidationResult("Amount is not valid",memberNames);
            }
            return ValidationResult.Success;
        }
    }
