    public class MyClass : IValidatableObject
    {               
        [Required(ErrorMessage="Start date and time cannot be empty")]
        //validate:Must be greater than current date
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }
        [Required(ErrorMessage="End date and time cannot be empty")]
        //validate:must be greater than StartDate
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }       
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (StartDateTime < DateTime.Now)
            {
                results.Add(new ValidationResult("Start date and time must be greater than current time", new []{"StartDateTime"}));
            }
            if (EndDateTime <= StartDateTime)
            {
                results.Add(new ValidationResult("EndDateTime must be greater that StartDateTime", new [] {"EndDateTime"}));
            }
            return results;
        }     
    }
