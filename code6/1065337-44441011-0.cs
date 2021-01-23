    //Declare logger type
    private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    Process.GetProcesses()
    .Where(p => { 
        try {
            var x = p.MainModule;
            return true;
        }
        catch(Win32Exception e2)
        { IgnoreError(); } 
        })
    .Select(p => p.MainModule.FileName)
    public static void IgnoreError(Exception e) 
    {
        #if DEBUG
        throw e2;
        //Save the error track, I prefer log4net
        _log.Info("Something bad happened!");
        #end if
    }
