    public class User: IValidatableObject
    {
         public int Id{get; set;}
         public string UserName{get; set;}
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
         {
              if(string.IsNullOrEmpty(UserName))
                   yield return new ValidationResult("Username field is required!", new string[]{"UserName"});
              else 
              {
                   // check if another User has the same username already
                   var db= new YourDbContext();
                   var exists=db.Users.FirstOrDefault(t=>t.Id!=Id && t.UserName.ToLower()=UserName.ToLower());
                   if(exists!=null)
                       yield return new ValidationResult("Username is already used by another user!", new string[]{"UserName"});
              }
         }
    }
