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
                        // yep, I know ... LINQ ... but this is from a plain .NET 2.0 source ...
                        terminalServicesSession = session;
                        break;
                    }
                }
            }
            return terminalServicesSession;
        }
