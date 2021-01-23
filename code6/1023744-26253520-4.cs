     System.Management.SelectQuery query = new System.Management.SelectQuery(@"Select * from Win32_ComputerSystem");
    
     //initialize the searcher with the query it is supposed to execute
     using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query))
     {
         //execute the query
         foreach (System.Management.ManagementObject process in searcher.Get())
         {
             //print system info
             process.Get();
             Console.WriteLine("/*********Operating System Information ***************/");
             Console.WriteLine("{0}{1}", "System Manufacturer:", process["Manufacturer"]);
             Console.WriteLine("{0}{1}", " System Model:", process["Model"]);
           
    
         }
     }
    
     System.Management.ManagementObjectSearcher searcher1 = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
     System.Management.ManagementObjectCollection collection = searcher1.Get();
    
    
    foreach (ManagementObject obj in collection)
    {
        if ( ((string[])obj["BIOSVersion"]).Length > 1)
            Console.WriteLine("BIOS VERSION: " + ((string[])obj["BIOSVersion"])[0] + " - " + ((string[])obj["BIOSVersion"])[1]);
        else
            Console.WriteLine("BIOS VERSION: " + ((string[])obj["BIOSVersion"])[0]);
    }
