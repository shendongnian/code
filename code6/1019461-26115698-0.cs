     class Example_Validation : ValidationRule
     {
        /// <summary>
        /// Example of a simple validation, that can have different validation error contents.
        /// </summary>
        /// <param name="value">A string in this case</param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;      // Convert to our string
            var sb = new StringBuilder();   // For the error messages
            var valid = true;               // Rather obvious
            if (String.IsNullOrWhiteSpace(str))
            {
                valid = false;
                sb.AppendLine("Null or white space is not valid.");
            }
            else if (str.Length < 5)
            {
                valid = false;
                sb.AppendLine("String too short (less than 5).");
            }
            return new ValidationResult(valid, sb.ToString());
        }
    }
