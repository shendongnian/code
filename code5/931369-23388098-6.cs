    public class PasswordModel
    {
        [Display(Name = "Password", Prompt = "Password")]
        [StringLength(255, MinimumLength = 7, ErrorMessage = "The password must be at least 7 characters")]
        [Required]
        [DataType(DataType.Password)]
    }
    public class UserAccount : PasswordModel
    {
        [Display(Name = "Username", Prompt = "Login As"), Required()]
        string UserName { get; set; }
    }
    public class ResetPasswordViewModel : PasswordModel
    {
        [Display(Name = "Retype Password", Prompt = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Password does not match")]
        string Password { get; set; }
    }
