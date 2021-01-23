    class Cart : IEquatable<Cart>
    { 
    	public int pID 
    	{ get; set; } 
    	public string pName 
    	{ get; set; } 
    	public string pDesc 
    	{ get; set; } 
    	public int pPrice { get; set; } 
    	public int pAmount { get; set; } 
    	public int pTotal { get; set; } 
    	public bool Equals(Cart other)
    	{
    		if (this.pID == other.pID)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    	
    } 
