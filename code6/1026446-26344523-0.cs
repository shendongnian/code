    // Interface to define individual fields:
    public interface IHasIndividualDateOfBirth
    {
      int BirthDay { get; set; }
      int BirthMonth { get; set; }
      int BirthYear { get; set; }
    }
    // Note new class level attribute, and interface declaration:
    [MinAge(AgeInYears = 18)]
    public class Birthday: IHasIndividualDateOfBirth
    {
      [Required]
      [Range(1, 31)]
      public int BirthDay { get; set; }
      [Required]
      [Range(1, 12)]
      public int BirthMonth { get; set; }
      [Required]
      [Range(1800, 2200)]
      public int BirthYear { get; set; }
      public DateTime BirthDate { get; set; }
    }
    // Declare a new ValidationAttribute that can be used at the class level:
    [AttributeUsage(AttributeTargets.Class)]
    public class MinAgeAttribute : ValidationAttribute
    {
      public int AgeInYears { get; set; }
      // Implement IsValid method:
      protected override ValidationResult IsValid(object value, 
                                                  ValidationContext validationContext)
      {
        // Retrieve the object that was passed in as our DateOfBirth type
        var objectWithDob = validationContext.ObjectInstance 
                              as IHasIndividualDateOfBirth;
        if (null != objectWithDob)
        {
          DateTime dateOfBirth = new DateTime(objectWithDob.BirthYear, 
                                              objectWithDob.BirthMonth, 
                                              objectWithDob.BirthDay);
          // Check that the age is more than the minimum requested
          if (DateTime.Now >= dateOfBirth.AddYears(AgeInYears))
          {
            return ValidationResult.Success;
          }
          return new ValidationResult("You are not yet 18 years old");
        }
        return new ValidationResult("Class doesn't implement IHasIndividualBirthday");
      }
    }
