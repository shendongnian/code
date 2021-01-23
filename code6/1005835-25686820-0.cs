    public class TestCompareModel : IValidatableObject
    {
        [Required]
        public Int32 Low { get; set; }
        [Required]
        public Int32 High { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (High < Low)
                results.Add(new ValidationResult("High cannot be less than low"));
            return results;
        }
    }
