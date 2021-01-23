    public class MyViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        public System.DateTime Dob { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Dob >= DateTime.Today)
                yield return new ValidationResult("Dob date should be set in the past", new [] { "Dob" });
        }
    }
