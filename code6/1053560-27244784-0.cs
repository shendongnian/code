    SelectQuery query = new SelectQuery(@"Select * from Win32_OperatingSystem");
    string wmiVersion = String.Empty;
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
    {                    
      foreach (var process in searcher.Get())
      {
         wmiVersion = process["Version"].ToString().Substring(0, 3);
      }
    }  
    switch (wmiVersion)
    {
     case "6.3": return "Windows 8.1";
     // ...
    }
