    interface IMaterializable
    {
        void OnMaterialized();
    }
    class SomeEntity : IMaterializable, IValidatableObject
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        //... Other properties
        public virtual ICollection<SomeOtherEntity> relatedEntity { get; set; }
        int OriginalStatusId;
        public void OnMaterialized()
        {
            OriginalStatusId = StatusId;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // compare current status to original + related
        }
    }
