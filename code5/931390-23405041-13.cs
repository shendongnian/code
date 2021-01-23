    public class UserAccount
    {
         [Display(Name = "Username", Prompt = "Login As"), Required()]
         string UserName { get; set; }
         [Display(Name = "Password", Prompt = "Password"), Required(), DataType(DataType.Password), StringLength(255, MinimumLength = 7, ErrorMessage = "The password must be at least 7 characters")]
         string Password { get; set; }
    }
