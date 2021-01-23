    public class LoginModel
    {
    	[Display(Name = "User Name")]
    	[Required(ErrorMessage = "Please fill in your user name.")]
    	public string UserName { get; set; }
    	
    	[Required(ErrorMessage = "Please fill in your password.")]
    	public string Password { get; set; }
    	
    	public bool RememberMe { get; set; }
    }
