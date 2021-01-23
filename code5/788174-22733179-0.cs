    public void ConnectToDbAdmin(string server, string user, string pass)
    {
        NRTDMS nrtDMS = new NRTDMS();
        NRTSession nrtSession;
        NRTSessions nrtSessions;
    
        nrtSessions = nrtDMS.Sessions;
        nrtSessions.Add(server);
        nrtSession = nrtSessions.Item(1);
    
        nrtSession.Login(user, pass);
        //or
        nrtSession.TrustedLogin();
    }
