    public class MyModel : PropertyValidation
    {
       [Required(ErrorMessage = "Name must be specified")]
       [MaxLength(50, ErrorMessage = "Name too long, Name cannot contain more than 50 characters")]
       public string Name {
          get { return GetValue(() => Name); }
          set { SetValue(() => Name, value); }
       }
    
       [Required(ErrorMessage = "Description must be specified")]
       [MaxLength(150, ErrorMessage = "Description too long, Description cannot contain more than 150 characters")]
       public string Description {
          get { return GetValue(() => Description); }
          set { SetValue(() => Description, value); }
       }
    }
