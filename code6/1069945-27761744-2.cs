	public class User
	{
    	public string nickname { get; set; }
    	public object id { get; set; }
    	public int account_id { get; set; } // you cant change the name*
	}
	public class Users
	{
	    public string status { get; set; } // you cant skip this
	    public int count { get; set; } // you cant skip this
	    public List<User> data { get; set; }
	}
