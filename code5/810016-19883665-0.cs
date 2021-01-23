    class Car
    {
    	public String make { get; set; }
    	public String model { get; set; }
    	public override bool Equals(object obj)
    	{
    		var other = obj as Car;
    		return (other != null) 
    				&& (this.make == other.make) 
    				&& (this.model == other.model); 
    	}
    	public override int GetHashCode()
    	{
    		return make.GetHashCode() ^ model.GetHashCode();
    	}
    }
