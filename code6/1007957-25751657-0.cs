    ITerminalServicesManager manager = new TerminalServicesManager();
            using (ITerminalServer server = manager.GetLocalServer())
            {
                server.Open();
                var result = server.GetSessions().Where(x => x.UserName == "name").SingleOrDefault();
                Console.WriteLine(result.SessionId);
            }
