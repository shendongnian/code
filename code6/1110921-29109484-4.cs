    [Serializable]
    public class UserViewModel : IValidatableObject 
        {
          [Required(ErrorMessage("Must provide LastName")]
          public string LastName {get;set;}
          public string FirstName {get;set;}
          public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
           if(LastName.Length>30) yield return new ValidationResult("Lastname must be less than 30 chars");
        }
    }
