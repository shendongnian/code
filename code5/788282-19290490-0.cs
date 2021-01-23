    public class RegisterModel
    {
    	[Required]
    	public string UserName { get; set; }
    	
    	[Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password")]
    	public string Password { get; set; }
    }
