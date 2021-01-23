    public class Role : IValidatableObject {
       public int Id {get; set;}
    
       [Required(ErrorMessage = "Please enter a role name")]
       public string Name {get; set;}
    
       public bool IsCreator {get; set;}
    
       public bool IsEditor {get; set;}
    
       public bool IsPublisher {get; set;}
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
           if (this.IsCreator || this.IsEditor || this.IsPublisher) {
               yield return new ValidationResult("You must be a creator, editor or publisher");
           }
       }
    }
