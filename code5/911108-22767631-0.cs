    public class YearValidationRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
    	    DateTime date = value as DateTime;
            if (date == null)
                return new ValidationResult(false, "Chosen date cannot be null.");
        
    	    if(BlackoutDatesDates.Contains(date))
                return new ValidationResult(false, "This date is blacked out.");
    			
            return ValidationResult.ValidResult;
        }
    }
