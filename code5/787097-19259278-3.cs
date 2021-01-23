    public class NamesValidationRule : ValidationRule
    {
        public string MinimumLetters { get; set; }
    
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if(str == null)
                return new ValidationResult(false, "Please enter first name");
            if(str.Length < MinimumLetters)
                return new ValidationResult(false, string.Format("Minimum Letters should be {0}", MinimumLetters));
            return new ValidationResult(true, null);    
        }
    }
