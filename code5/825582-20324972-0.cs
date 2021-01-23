    public class User
    {
    	[Required]
    	public string UserName { get; set; }
    	
    	[Required]
    	[MaxLength(36)] // The password is hashed so it won't be bigger than 36 chars.
    	public string Password { get; set; }
    	
    	public string FullName { get; set; }
    	
    	public string SalesRepresentative { get; set; }
    	
    	// etc..
    }
