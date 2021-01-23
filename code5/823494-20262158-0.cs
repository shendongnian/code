     SelectQuery qry = new SelectQuery("PrintJob");
      using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry))
      using (ManagementObjectCollection printJobs = searcher.Get())
         foreach (ManagementObject printJob in printJobs)
           {
        string name = (string) product["Name"];
        string[] nameParts = name.Split(',');
        string printerName = nameParts[0];
        string jobNumber = nameParts[1];
        string document = (string) product["Document"];
        string jobStatus = (string) product["JobStatus"];
           }
