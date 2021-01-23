    LogWriter logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
    try
    {
        logWriter.Write("Test", "General");
    }
    catch (Exception e)
    {
        Console.WriteLine("LogWriter.Write() threw an exception: " + e);
    }
