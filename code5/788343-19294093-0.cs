    [MetadataType(typeof(SeasonMetaData))]
        public partial class Season : IValidatableObject
        {
            #region IValidatableObject Members
    
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (this.StartDate.CompareTo(this.EndDate) >= 0)
                {
                    yield return new ValidationResult("The Season End must be after the Season Start.", new String[] { "EndDate" });
                }
            }
    
            #endregion
            
        }
