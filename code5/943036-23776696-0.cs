    System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_LogicalDisk");
                
    System.Management.ManagementObjectCollection moc = mc.GetInstances();
    if (moc.Count != 0)
    {
    	foreach (System.Management.ManagementObject mo in mc.GetInstances())
    	{
    		string providerName = string.Empty;
    
    		if (mo["ProviderName"] != null)
    		{
    			providerName = mo["ProviderName"].ToString();
    		}
    
    		Console.WriteLine("\nName: {0}\nVolume Name: {1}\nProvider Name: {2}",
    						  mo["Name"].ToString(),
    						  mo["VolumeName"].ToString(),
    						  providerName);
    	}
    }
