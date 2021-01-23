    public class UserViewModel : IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // validate the unencrypted password's length to be < 20
            if (this.Password.Length > 20)
            {
                yield return new ValidationResult("Password too long!");
            }
        }        
    }
