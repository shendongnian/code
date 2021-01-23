    [Serializable]
    public class UserViewModel : IValidatableObject 
        {
          public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
           if(somepropertynotright) yield return new ValidationResult("Fail this validation");
        }
    }
