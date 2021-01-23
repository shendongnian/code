    //session end
    void Session_End(object sender, EventArgs e)
    {
        object sessionPID = Session["_servicePID"];
        if (sessionPID != null && sessionPID is int)
        {
            Process runningProcess = Process.GetProcessById((int)sessionPID);
            if (runningProcess != null)
                runningProcess.Kill();
        }
    }
    
    //application end
    void Application_End(object sender, EventArgs e)
    {
        object applicationPID = Application["_applicationPID"];
        if (applicationPID != null && applicationPID is int && Process.GetProcessById((int)applicationPID) != null)
        {
            Process runningProcess = Process.GetProcessById((int)applicationPID);
            if (runningProcess != null)
                runningProcess.Kill();
        }
    }
