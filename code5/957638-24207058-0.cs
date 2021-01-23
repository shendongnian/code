    class Email
    {
    	private string user;
    	private string domain;
    
    	public Email(string user, string domain)
    	{
    		this.user = user;
    		this.domain = domain;
    	}
    
    	static public implicit operator Email(string value) // magic goes here ;)
    	{
    		var parts = value.Split('@');
    		if (parts.Length != 2)
    			return null;
    
    		return new Email(parts[0], parts[1]);
    	}
    
    	static public implicit operator string(Email value)
    	{
    		return "{ User = " + value.user + ", Domain = " + value.domain + " }";
    	}
    }
    
    class Test
    {
    	static public void Main()
    	{
    		Email test = "alice@test.com"
    		
    		System.Console.WriteLine("Test: " + test);
    	}
    }
