    private void Method1()
    {
        //Do something
        Log("Something", System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    
    private void Method2()
    {
        //Do something
        Log("Something", System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    
    private void Log(string message, string method)
    {
        //Write to a log file
        Trace.TraceInformation(message + "happened at " + method);
    }
