    private string GetWMIProperty(string property)
    {
     string value = string.Empty;
     SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
     using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
     {
      
       foreach (ManagementObject mo in searcher.Get())
       {
         value = mo[property].ToString();
       }
     }
    return value;
    }
