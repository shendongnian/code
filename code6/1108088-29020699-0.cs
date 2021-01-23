    public class ConfigurationLoader()
    {
	    private readonly string _configFile;
	
	    public ConfigurationLoader()
	    {
		    #if DEBUG 
		        _configFile = "app.Debug.config"; 
		    #else 
		        _configFile = "app.Release.config";
		    #endif
	    }
	
	    public UniversalAppConfig LoadCofig()
	    {
		    // Read file
		
		    // Create UniversalAppConfig
	    }
    }
    public class UniversalAppConfig()
    {
	    public int ConfigurationValueA { get; set; }
	
	    public int ConfigurationValueB { get; set; }
    }
