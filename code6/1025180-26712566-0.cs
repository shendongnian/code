    public RAActivityContext()
    	: base((new SqlConnectionStringBuilder(
    			CloudConfigurationManager.GetSetting("dbRAActivity")).ToString()))
    {            
    	
    }
