    public void createProcessAsUser()
    {
        //one process per session
        object sessionPID = Session["_servicePID"];
        if (sessionPID != null && sessionPID is int && Process.GetProcessById((int)sessionPID) != null)
            return; //<-- Return process already running for session
        else
            Session.Remove("_servicePID");
    
        //one process per application
        object applicationPID = Application["_applicationPID"];
        if (applicationPID != null && applicationPID is int && Process.GetProcessById((int)applicationPID) != null)
            return; //<-- Process running for application
        else
            Application.Remove("_applicationPID");
    
        //omitted starting code
    
        if (ret == false)
            // omitted log failed
        else
        {
            // omitted log started
            //for one process per session
            Session["_servicePID"] = Convert.ToInt32(pi.dwProcessId);
    
            //for one process per application
            Application["_applicationPID"] = Convert.ToInt32(pi.dwProcessId);
                    
            //close handles
        }
    
        // omitted the rest of the method
    }
