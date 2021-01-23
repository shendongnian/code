    public class Company : Entity, IValidatableObject
    {
        public virtual ICollection<Profile> Profiles { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
            if (!Profiles.Any()) 
               yield return new ValidationResult("Company must have at least 1 Profile"); 
        }
    }
    
    public class Profile : Entity, IValidatableObject
    {
        public virtual ICollection<Company> Companies { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
            if (!Companies.Any()) 
               yield return new ValidationResult("Profile must have at least 1 Company"); 
        }
    }
