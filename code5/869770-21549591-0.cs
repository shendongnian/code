    public class Actor : AbstractDataholder, IValidatableObject
    {
        public string A { get; set; }
        public string B { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsnullorWhiteSpace(this.A) && string.IsnullorWhiteSpace(this.B))
                 return new ValidationResult("NOT VALID");            
        }
    }
