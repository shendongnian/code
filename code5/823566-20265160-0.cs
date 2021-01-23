    public class Schedule
    {
        ...
        public int BeginWork { get; set; }
        public int EndWork { get; set; }
   
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
         {
             if (BeginWork >= EndWork )
             {
                yield return new ValidationResult("The end work needs to be later than the begin work");
             }
         }
    }
