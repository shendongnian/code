    public partial class ExampleEntity : IValidatableObject
    {
        public bool OptionA { get; set; }
        public int OptionAValue { get;set; }
        public bool OptionB { get; set; }
        public int OptionBValue { get;set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OptionA)
            {
                var aIsValid = PerformAValidation();
                if (!aIsValid)
                {
                    yield return new ValidationResult("A was not valid", new[] {"OptionAValue", OptionAValue});
                }
            }
            if (OptionB)
            {
                var bIsValid = PerformBValidation();
                if (!bIsValid)
                {
                    yield return new ValidationResult("B was not valid", new[] {"OptionBValue", OptionBValue});
                }
            }
        }
        private bool PerformAValidation()
        {
            if (OptionAValue < 100)
            {
                return false;
            }
            return true;
        }
        private bool PerformBValidation()
        {
            if (OptionBValue > 100)
            {
                return false;
            }
            return true;
        }
    }
