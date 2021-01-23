    public class YourModelName : IValidatableObject
    {
      [StringLength(20)]
      public string Number{ get; set; }
      [Required]
      public DateTime? TimeOf { get; set; }
      public bool HasType { get; set; }
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
      { 
        var results = new List<ValidationResult>();
         
        Validator.TryValidateProperty(this.Number,
                new ValidationContext(this, null, null) { MemberName = "Number" },
                results);    
        if (TimeOf == null) 
           results.Add(new ValidationResult("Date Time must have a value"));
        if (!HasType)
           results.Add(new ValidationResult("Must be true"));
        
        return results;
      }
