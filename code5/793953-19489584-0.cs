    public class Foo
    {
        [Required]
        public string RequiredProperty { get; set; }
        [ValidateDictionary]
        public Dictionary<string, Bar> BarInstance { get; set; }
    }
    public class Bar
    {
        [Required]
        public string BarRequiredProperty { get; set; }
    }
    public class ValidateDictionaryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IsDictionary(value)) return ValidationResult.Success;
            var results = new List<ValidationResult>();
            var values = (IEnumerable)value.GetType().GetProperty("Values").GetValue(value, null);
            values.OfType<object>().ToList().ForEach(item => Validator.TryValidateObject(item, new ValidationContext(item, null, validationContext.Items), results));
            Validator.TryValidateObject(value, new ValidationContext(value, null, validationContext.Items), results);
            return results.FirstOrDefault() ?? ValidationResult.Success;
        }
        protected bool IsDictionary(object value)
        {
            if (value == null) return false;
            var valueType = value.GetType();
            return valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof (Dictionary<,>);
        }
    }
