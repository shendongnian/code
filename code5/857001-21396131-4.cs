    public void createProcessAsUser()
    {
        //find the http context
        var ctx = HttpContext.Current;
        if (ctx == null)
            throw new Exception("No Http Context");
    
        //use the following code for 1 process per user session
        object sessionPID = ctx.Session["_servicePID"];
        if (sessionPID != null && sessionPID is int && Process.GetProcessById((int)sessionPID) != null)
            return; //<-- Return process already running for session
        else
            ctx.Session.Remove("_servicePID");
    
        //use the following code for 1 process per application instance
        object applicationPID = ctx.Application["_applicationPID"];
        if (applicationPID != null && applicationPID is int && Process.GetProcessById((int)sessionPID) != null)
            return; //<-- Process running for application
        else
            ctx.Application.Remove("_applicationPID");
    
        // omitted code
    
        if (ret == false)
        {
            //omitted logging
        }
        else
        {
            //omitted logging
    
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
    
    
            //for one process per session
            ctx.Session["_servicePID"] = Convert.ToInt32(pi.dwProcessId);
    
            //for one process per application
            ctx.Application["_applicationPID"] = Convert.ToInt32(pi.dwProcessId);
        }
    
        //omitted the rest
    }
