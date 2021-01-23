        public class RegisterViewModel
    {
        [Display(Prompt = "Your Name", Name = "Contact Name"), Required(), StringLength(255, MinimumLength = 3, ErrorMessage = "Please enter a valid contact")]
        public string ContactName { get; set; }
        [Display(Name = "Username", Prompt = "Login As"), Required(), StringLength(255, MinimumLength = 3, ErrorMessage = "Your username must be at least 3 characters")]
        public string UserName { get; set; }
    [Display(Name = "Account Type", Prompt = "Account Type"), Required()]
        public AccountType AccountType { get; set; }
        [Display(Name = "Organisation Name", Prompt = "Name of Organisation"), StringLength(255)]
        public string OrganisationName { get; set; }
        public RegisterViewModel()
        {
            
        }
    
        [Display(Name = "Password", Prompt = "Password"), Required(), DataType(DataType.Password), StringLength(255, MinimumLength = 5, ErrorMessage = "The password must be at least 7 characters")]
        public string Password { get; set; }
    
        [Display(Name = "Confirm Password", Prompt = "Confirm Password"), Compare("Password", ErrorMessage = "Your confirmation doesn't match...")]
        public string PasswordConfirmation { get; set; }
    }
