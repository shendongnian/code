    private string _a;
		
    [DataMember]
    public string a 
    { 
    	get
    	{ 
    		if(_a == null)
    		{
    			return string.Empty;
    		}
    		return _a;
    	}
    	
    	set
    	{
    		_a = value
    	}
    }
