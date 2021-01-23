    public class YourEntity : IValidatableObject
    {
        [Required]
        public string Month { get; set; }
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            var months = Enumerable.Range(1, 12).Select(x => x.ToString("00"));
            if (!months.Contains(Month))
            {
                yield return 
                    new ValidationResult("Invalid month value.", new[] { "Month" });
            }
        }
    }
