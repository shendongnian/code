    private List<string> GetWMIProperty(string property)
    {
     SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
     using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
     {
       List<string> value =new  List<string>();
       foreach (ManagementObject mo in searcher.Get())
       {
         value.Add(mo[property].ToString());
       }
     }
    return value;
    }
