    private void Method1()
    {
        //Do something
        Log("Something");
    }
    
    private void Method2()
    {
        //Do something
        Log("Something");
    }
    
    private void Log(string message, [CallerMemberName] string method = null)
    {
        //Write to a log file
        Trace.TraceInformation(message + "happened at " + method);
    }
