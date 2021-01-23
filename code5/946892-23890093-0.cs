    using System.Configuration;
    
    public class ConfigHelper
    {
    	private const string ConfigPathString = @"{0}\MyApp\App.config";
    
    	private string ConfigPath
    	{
    		get { return String.Format( ConfigPathString, System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) ); }
    	}
    
    	private Configuration Config
    	{
    		get
    		{
    			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
    			fileMap.ExeConfigFilename = ConfigPath;
    
    			return ConfigurationManager.OpenMappedExeConfiguration( fileMap, ConfigurationUserLevel.None );
    		}
    	}
    
    	public string ReadConString()
    	{
    		Configuration cfg = Config;
    		return cfg.ConnectionStrings.ConnectionStrings[DefaultConnectionStringKey].ConnectionString;
    	}
    }
