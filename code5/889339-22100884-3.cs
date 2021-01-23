    private List<string> GetWMIProperty(string property)
    {
     List<string> value =new  List<string>();
     SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
     using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
     {
       
       foreach (ManagementObject mo in searcher.Get())
       {
         value.Add(mo[property].ToString());
       }
     }
    return value;
    }
