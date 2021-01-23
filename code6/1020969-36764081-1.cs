    public static void DisableOcr()
    {
    	RegistrySettings registry;
    	try
    	{
    		registry = RegistrySettings.Parse();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    		return;
    	}
    	registry.RunOcr = 0;
    	registry.IncludeComments = 0;
    	registry.Save();
    }
