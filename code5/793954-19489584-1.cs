    public class Foo
    {
        [Required]
        public string RequiredProperty { get; set; }
        public ValidatableDictionary<string, Bar> BarInstance { get; set; }
    }
    public class Bar
    {
        [Required]
        public string BarRequiredProperty { get; set; }
    }
    public class ValidatableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Values.ToList().ForEach(item => Validator.TryValidateObject(item, new ValidationContext(item, null, validationContext.Items), results));
            return results;
        }
    }
