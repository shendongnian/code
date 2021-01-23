    private static void OpenProcessIfNeeded(String file)
    {
    	using (ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process"))
    	{
    		foreach (ManagementObject mo in mos.Get())
    		{
    			if (mo["CommandLine"] != null &&
    				mo["CommandLine"].ToString().IndexOf(file, StringComparison.InvariantCultureIgnoreCase) > -1)
    			{
    				Console.WriteLine("Found!: " + mo["CommandLine"]);
    				return;
    			}
    		}
    	}
    	Process.Start(file);
    }
