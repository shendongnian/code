    // string.Empty or null for local printers
    string printServerName = @"\\server";
    string printerName = "printer";
        
    PrintServer ps = string.IsNullOrEmpty(printServerName)
        // for local printers
        ? new PrintServer()
        // for shared printers
        : new PrintServer(printServerName);
    PrintQueue pq = ps.GetPrintQueue(printerName);
        
    Console.WriteLine(pq.FullName);
    Console.WriteLine(pq.NumberOfJobs);
    // output is printer uri (\\server\printer) and 0.
