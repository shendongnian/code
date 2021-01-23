    public class MyModel : IValidatableObject
    {
      public int Year { get; set; }
      public int Month { get; set; }
      public int Day { get; set; }
      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
          if (/*Validate properties here*/) yield return new ValidationResult("Invalid Date!", new[] { "valideDate" });
      }
    }
