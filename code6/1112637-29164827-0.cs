    public void ConfigureWindowsRegistry()
    {
    	RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); //here you specify where exactly you want your entry
    	 
       var reg = localMachine.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\FormRegions\\tesssst",true);
       if (reg == null)
       {
           reg = localMachine.CreateSubKey("Software\\Microsoft\\Office\\Outlook\\FormRegions\\tesssst");
       }
    
       if (reg.GetValue("someKey") == null)
       {
           reg.SetValue("someKey", "someValue");
       }
    }
