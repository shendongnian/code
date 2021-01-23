    using System.Diagnostics;
    ...
    private string GetOperatingSystemInfo()
    {
        RegistryKey operatingSystemKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
        string operatingSystemName = operatingSystemKey.GetValue("ProductName").ToString();
    
        ConnectionOptions options = new ConnectionOptions();
        // query any machine on the network     
        ManagementScope scope = new ManagementScope("\\\\machineName\\root\\cimv2", options);
        scope.Connect();
        // define a select query
        SelectQuery query = new SelectQuery("SELECT OSArchitecture, CSDVersion FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
       
        string osArchitecture = "";
        string osServicePack = "";
    
        foreach (ManagementObject mo in searcher.Get())
        {
    	    osArchitecture = mo["OSArchitecture"].ToString();
       	    osServicePack = mo["CSDVersion"].ToString();               
        }            
        return operatingSystemName + " " + osArchitecture + " " + osServicePack;                         
    }
