    public class UserAccount : PasswordModel
    {
        [Display(Name = "Username", Prompt = "Login As"), Required()]
        public string UserName { get; set; }
        [Display(Name = "Password", Prompt = "Password")]
        [StringLength(255, MinimumLength = 7, ErrorMessage = "The password must be at least 7 characters")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class ResetPasswordViewModel : PasswordModel
    {
        [Display(Name = "Retype Password", Prompt = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Password does not match")]
        string RetypePassword { get; set; }
    }
