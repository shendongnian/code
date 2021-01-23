    private const string baseReg =
    	@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002bE10318}\";
    
    public static bool SetMAC(string nicid, string newmac)
    {
    	bool ret = false;
    	using (RegistryKey bkey = GetBaseKey())
    	using (RegistryKey key = bkey.OpenSubKey(baseReg + nicid))
    	{
    		if (key != null)
    		{
    			key.SetValue("NetworkAddress", newmac);
    
    			ManagementObjectSearcher mos = new ManagementObjectSearcher(
    				new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Index = " + nicid));
    
    			foreach (ManagementObject o in mos.Get().OfType<ManagementObject>())
    			{
                    try
                    {
                        o.InvokeMethod("Disable", null);
                        o.InvokeMethod("Enable", null);
                        ret = true;
                    }
                    catch (Exception)
                    {
                        // Some NICs won't allow this
                    }
    			}
    		}
    	}
    
    	return ret;
    }
    
    public static string[] GetNicIds()
    {
    	using (RegistryKey bkey = GetBaseKey())
    	using (RegistryKey key = bkey.OpenSubKey(baseReg))
    	{
    		return key != null ? key.GetSubKeyNames() : new string[0];
    	}
    }
    
    public static RegistryKey GetBaseKey()
    {
    	return RegistryKey.OpenBaseKey(
            RegistryHive.LocalMachine,
            InternalCheckIsWow64() ? RegistryView.Registry64 : RegistryView.Registry32);
    }
