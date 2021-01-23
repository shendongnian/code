    ITerminalServicesManager manager = new TerminalServicesManager();
    using (ITerminalServer server = manager.GetLocalServer())
    {
        server.Open();
        foreach (ITerminalServicesSession session in server.GetSessions())
        {
            Console.WriteLine("Hi there, " + session.UserAccount + " on session " + session.SessionId);
            Console.WriteLine("It looks like you logged on at " + session.LoginTime +
                              " and are now " + session.ConnectionState);
        }
    }
