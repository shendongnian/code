        ITerminalServicesSession GetActiveSession()
        {
            var terminalServicesSession = default(ITerminalServicesSession);
            var terminalServicesManager = new TerminalServicesManager();
            using (var server = terminalServicesManager.GetLocalServer())
            {
                foreach (var session in server.GetSessions())
                {
                    if (session.ConnectionState == ConnectionState.Active)
                    {
                        terminalServicesSession = session;
                        break;
                    }
                }
            }
            return terminalServicesSession;
        }
