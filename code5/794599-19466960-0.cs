    public class Entity
    {
    	public int Id { get; set; }
    	public string Code { get; private set; }
    
    	public string MyCode 
    	{ 
    		get { return this.Code; }
    		set
    		{
    			if (string.IsNullOrEmpty(this.Code))
    			{
    				this.Code = value;
    			}
    		}
    	}
    }
