    // Microsoft.Tools.Common.SdkPathUtility
    private static string GetRegistryValue(string registryPath, string registryValueName)
    {
    	string result;
    	try
    	{
    		using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
    		{
    			using (RegistryKey registryKey2 = registryKey.OpenSubKey(registryPath, false))
    			{
    				string text = registryKey2.GetValue(registryValueName, string.Empty) as string;
    				result = text;
    			}
    		}
    	}
    	catch (UnauthorizedAccessException)
    	{
    		result = string.Empty;
    	}
    	catch (SecurityException)
    	{
    		result = string.Empty;
    	}
    	return result;
    }
