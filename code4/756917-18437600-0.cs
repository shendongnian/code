    internal class Helper
    {
    	public static void SetBrowserEmulation(
    		string programName, IE browserVersion)
    	{
    		if (string.IsNullOrEmpty(programName))
    		{
    			programName = AppDomain.CurrentDomain.FriendlyName;
    			RegistryKey regKey = Registry.CurrentUser.OpenSubKey(
    				"Software\\Microsoft\\Internet Explorer\\Main" + 
    				"\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
    			if (regKey != null)
    			{
    				try
    				{
    					regKey.SetValue(programName, browserVersion, 
    						RegistryValueKind.DWord);
    				}
    				catch (Exception ex)
    				{
    					throw new Exception("Error writing to the registry", ex);
    				}
    			}
    			else
    			{
    				try
    				{
    					regKey = Registry.CurrentUser.OpenSubKey("Software" + 
    						"\\Microsoft\\Internet Explorer\\Main" + 
    						"\\FeatureControl", true);
    					regKey.CreateSubKey("FEATURE_BROWSER_EMULATION");
    					regKey.SetValue(programName, browserVersion,
    						RegistryValueKind.DWord);
    				}
    				catch (Exception ex)
    				{
    					throw new Exception("Error accessing the registry", ex);
    				}
    			}
    		}
    	}
    }
    internal enum IE
    {
    	IE7 = 7000,
    	IE8 = 8000,
    	IE8StandardsMode = 8888,
    	IE9 = 9000,
    	IE9StandardsMode = 9999,
    	IE10 = 10000,
    	IE10StandardsMode = 10001
    }
