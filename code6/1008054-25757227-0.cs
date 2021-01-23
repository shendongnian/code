    interface IMaterializable
    {
        void OnMaterialized();
    }
    class SomeEntity : IMaterializable, IValidatableObject
    {
        public int Status { get; set; }
        int OriginalStatus;
        public void OnMaterialized()
        {
            OriginalStatus = Status;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // compare current status to original
        }
    }
