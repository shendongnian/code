    public class Byte20ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int byteCount = Encoding.UTF8.GetByteCount(value.ToString());
            if (byteCount <= 20)
                return new ValidationResult(true, null);
  
            return new ValidationResult(false, "Too many bytes.");
        }
    }
