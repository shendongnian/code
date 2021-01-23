    private string GetWMIProperty(string property)
    {
     SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
     using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
     {
       string value = string.Empty;
       foreach (ManagementObject mo in searcher.Get())
       {
         value = mo[property].ToString();
       }
     }
    return value;
    }
