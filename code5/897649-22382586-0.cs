    // ---- Create Event Log Source ---------------------------------
    //
    // returns True if is it created or already exists.
    //
    // Only administrators can create event logs.
    
    static public bool CreateEventLogSource()
    {
        System.Diagnostics.Debug.WriteLine("CreateEventLogSource....");
    
        try
        {
            // this call is looking for this RegKey: HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\EventLog\Application\<app Name>
            if (EventLog.SourceExists(Application.ProductName))
            {
                System.Diagnostics.Debug.WriteLine("Log exists, returning true.");
                return true;
            }
        }
        catch (System.Security.SecurityException)
        {
            // it could not find the EventLog Source and we are not admin so this is thrown 
            // when it tries to search the Security Log. 
            // We know it isn't there so ignore this exception
        }
    
        System.Diagnostics.Debug.WriteLine("EventLog Source doesn't exist....try to create it...");
    
        if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
            System.Diagnostics.Debug.WriteLine("Running as Admin....trying to create....");
            try
            {
                EventLog.CreateEventSource(Application.ProductName, "Application");
    
                System.Diagnostics.Debug.WriteLine("Successfully create EventLogSource");
                return true;
            }
            catch (Exception Exp)
            {
                Utils.MessageBoxError("Error Creating EventLog Source: " + Exp.Message);
                return false;
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Need to restart with admin roles");
    
            ProcessStartInfo AdminProcess = new ProcessStartInfo();
            AdminProcess.UseShellExecute = true;
            AdminProcess.WorkingDirectory = Environment.CurrentDirectory;
            AdminProcess.FileName = Application.ExecutablePath;
            AdminProcess.Verb = "runas";
    
            try
            {
                Process.Start(AdminProcess);
                return false;
            }
            catch
            {
                Utils.MessageBoxError("The EventLog source was NOT created");
                // The user refused to allow privileges elevation.
                return false;
            }
        }
    }
