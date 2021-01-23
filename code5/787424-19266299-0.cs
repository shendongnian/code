    public static class ConfigParams
    {
    	// Either properties for every parameter:
    	
    	public static string Culture { get; set; }
    	
    	public static string WebsiteTitle { get; set; }
    	public static DateTime LastUpdate { get; set; }
    	
    	// Or a dictionary containing all the properties accessed by a string:
    	
    	Dictionairy<string, object> Params { get; set; }	
    }
