    public class AccountCredentials : AccountEmail
    {
     [Required(ErrorMessage = "xxx.")]
     [StringLength(30, MinimumLength = 6, ErrorMessage = "xxx")]
     public virtual string password { get; set; }
    }
    
    public class PasswordReset : AccountCredentials
    {
     [Required]
     public string resetToken { get; set; }
     public override string password { get; set; }
    }
 
