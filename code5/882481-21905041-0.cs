    public class NewModel 
    {
          [EmailValidation(ErrorMessage = "The Email Address already exists")]
          [RegularExpression( "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$" , ErrorMessage = "Invalid email format." )]
          [Required(ErrorMessage = "Please enter your e-mail address."), StringLength(50)]
          public string Email { get; set; }
    {
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropmetEntities db = new PropmetEntities();
            if (value != null)
            {
                var valueAsString = value.ToString();
                IEnumerable<string> email = db.ContactInformations.Where(x => x.EMail != null).Select(x => x.EMail);
                if (email.Contains(valueAsString))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
