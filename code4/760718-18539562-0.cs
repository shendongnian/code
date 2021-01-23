    public class myObject
    {
    	public int ID    // this is now a property
    	{
    		get;
    		set;
    	}
    
    	public string Name
    	{
    		get;
    		set;
    	}
    
    	public myObject(
    		int id,
    		string name
    		)
    	{
    		this.ID = id;
    		this.Name = name;
    	}
    }
