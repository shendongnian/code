    public class YourContext : DbContext
    {	
    	public YourContext()
    	{
    		Database.Log = sql => Debug.Write(sql);
    	}
    }
