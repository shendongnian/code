    public class Value : IValidatableObject {
        public bool Show { get; set; }
        public bool Required { get; set; }
        [RequiredIf("Show", Domain.Comparison.IsEqualTo, true, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = "AuthorLabelIsRequired")]
        public string Label { get; set; }
        public string Description { get; set; }
        [RequiredIf("Show", Domain.Comparison.IsEqualTo, true, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = "AuthorLabelIsRequired")]
        public int? Maximum { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (this.Show && !this.Maximum.HasValue) {
                yield return new ValidationResult("You must specify a maximum value");
            }
        }
    }
