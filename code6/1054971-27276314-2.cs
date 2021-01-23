    public class Awesome : IValidatableObject {
        [Required]
        public Int32 Id { get; set; }
        public String Whatever { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            // Perform validation checks...
            // If 'valid' return <null>,
            // and if not, populate the ValidationResult list and return that.
            // The validationContext.ObjectInstance contains what you need, if you
            // cast it properly (see my next example).
        }
    }
