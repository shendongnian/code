    class ServerQueue
        {
            private List<Script> Servers = new List<Script>();
    
            public void Add(Script Server)
            {
                Servers.Add(Server);
                Server.Exited += cmd_Exited;
            }
    
            public void RunNextScript()
            {
                if (Servers.Count > 0)
                {
                    Script ToRun = Servers[0];
                    Servers.Remove(ToRun);
                    ToRun.StartProcess();
                }
            }
    
            public void StartFirstScripts()
            {
                byte Running = 0;
                while (Servers.Count > 0 && Running <= 20)
                {
                    RunNextScript();
                    Running++;
                }
            }
            private void cmd_Exited(object sender, EventArgs e)
            {
                Exited(this);
                RunNextScript();
            }
        }
