    private List<string> GetWMIProperty(string property)
       {
           List<string> values = new List<string>();
           SelectQuery selectQuery = new SelectQuery("Win32_OperatingSystem");
           using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery))
           {
               foreach (ManagementObject mo in searcher.Get())
               {
                   values.Add(mo[property].ToString());
               }
           }
           return values
       }
