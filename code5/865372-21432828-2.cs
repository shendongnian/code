    public class PropertVal:ValidationRule
    {
        private readonly List<String> validValues = new List<String> { "aa", "bb", "cc", "dd" };
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "The Field are not match");
            string val = value.ToString().Trim();
            bool isValid = !string.IsNullOrEmpty(val) && validValues.Contains(val);
            ValidationResult result = null;
            result = isValid
                         ? new ValidationResult(true, null)
                         : new ValidationResult(false, "The Field are not match");
            return result;
        }
        public void AddListItem(string item)
        {
            //...
        }
        public void RemoveItem(string item)
        {
            //...
        }
    }
