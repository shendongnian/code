    public class OptionalPassword : ValidationAttribute
    {
        private static Regex passwordPattern = 
            new Regex(@"^()|([a-zA-Z0-9]{3,40})$", 
                      RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
        public override bool IsValid(object value, ValidationContext context)
        {
            var password = value as string;
    
            if (string.IsNullOrEmpty(password)) {
                return true;
            }
    
            return passwordPattern.IsMatch(password);
        }
    }
