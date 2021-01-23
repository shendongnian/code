    public class SomeClass: IValidatableObject {
        private RegEx validation;
        public SomeClass(RegEx val) {
            this.validation = val;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            // perform validation logic - check regex etc...
            // if an error occurs:
            results.Add(new ValidationResult('error message'));
        }
    }
