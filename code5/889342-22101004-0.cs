    private string GetWMIProperty(string property)
    {
        SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
        {
    		...
        }
    	
        thrown new ArgumentException("no WMI property found for specified property name", "property");
    }
