    string scope = "root/WMI";
    string query = "SELECT DesignedCapacity FROM BatteryStaticData";
    
    ManagementObjectSearcher batteriesQuery = new ManagementObjectSearcher(scope, query);
    
    ManagementObjectCollection batteries = batteriesQuery.Get();
    
    foreach (ManagementObject battery in batteries)
    {
    	if (battery != null)
    	{
    		foreach (var property in battery.Properties)
    		{
    			Console.Log("Property name: " + property.Name + " Property value: " + property.Value);
    		}
    	}
    }
