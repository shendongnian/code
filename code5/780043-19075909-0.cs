    void Session_Start(object sender, EventArgs e)
    {
        //Add to ConcurrentDictionary
    }
 
    void Session_End(object sender, EventArgs e)
    {
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //Remove from ConcurrentDictionary
    }
