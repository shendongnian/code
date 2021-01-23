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
            RunNextScript();
        }
    }
    class Script
    {
        public string Output
        {
            get
            {
                return pOutput;
            }
        }
        public string Errors
        {
            get
            {
                return pErrors;
            }
        }
        public bool IsRunning
        {
            get
            {
                return pIsRunning;
            }
        }
        private string pOutput = "";
        private string pErrors = "";
        private bool pIsRunning = false;
        public delegate void OutputEventHandler(Script sender, string Output, bool IsError);
        public delegate void StatusEventHandler(Script sender, EventArgs e);
        public event OutputEventHandler OutputDataReceived;
        public event OutputEventHandler ErrorDataReceived;
        public event StatusEventHandler Started;
        public event StatusEventHandler Exited;
        private Process cmd;
        public void StartProcess()
        {
            pIsRunning = true;
            cmd.Start();
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();
            Started(this, null);
        }
        public void KillProcess()
        {
            if (IsRunning)
            {
                cmd.Kill();
            }
        }
        public void SetupScript()
        {
            cmd = new Process();
            cmd.EnableRaisingEvents = true;
            cmd.Exited += new EventHandler(cmd_Exited);
            //configure Process (but don't start it yet)
        }
        private void cmd_Exited(object sender, EventArgs e)
        {
            pIsRunning = false;
            Exited(this, null);
            //do other stuff
        }
        private void cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived(this, e.Data, false);
            //do stuff
        }
        private void cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            ErrorDataReceived(this, e.Data, true);
            //do stuff
        }
    }
