    public class RegisterViewModel
{
    [Display(Prompt = "Your Name", Name = "Contact Name"), Required(), StringLength(255, MinimumLength = 3, ErrorMessage = "Please enter a valid contact")]
    public string ContactName { get; set; }
    [Display(Name = "Username", Prompt = "Login As"), Required(), StringLength(255, MinimumLength = 3, ErrorMessage = "Your username must be at least 3 characters")]
    public string UserName { get; set; }
