    string logName = "Microsoft-Windows-PrintService/Operational";
    EventLogConfiguration log = new EventLogConfiguration(logName);
                
    log.IsEnabled = true;
    
    try
    {
        log.SaveChanges();
    }
    catch (UnauthorizedAccessException e)
    {
        Console.WriteLine("You need administrator privileges. " + e.Message);
    }
