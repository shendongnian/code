    public struct CustomDateTime
    {
    	private DateTime UnderlyingDateTime;
    
    	[XmlText]
    	public string CustomFormat
    	{
    		get { return UnderlyingDateTime.ToString(); }
    		set { UnderlyingDateTime = System.DateTime.Parse(value); }
    	}
    	
    	public static implicit operator DateTime(CustomDateTime custom)
    	{
    		return custom.UnderlyingDateTime;
    	}
    	
    	public static implicit operator CustomDateTime(DateTime datetime)
    	{
    		return new CustomDateTime { UnderlyingDateTime = datetime };
    	}
    }
