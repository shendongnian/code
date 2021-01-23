    System.Diagnostics.EventLog eventLog1 = new System.Diagnostics.EventLog();    
    eventLog1.Log = "Diagnostics-Performance";
    foreach (System.Diagnostics.EventLogEntry entry in eventLog1.Entries)
    {
        Console.WriteLine(entry.Message);
    }
