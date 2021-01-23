    class Program
    {
        static void Main(string[] args)
        {
            ProcessEx s = new ProcessEx();
            s.SetupProcess(@"C:\MyP\MBN\Dev\Test\Hello\bin\Debug\Hello.exe", "process 0");
            ProcessExQueue q = new ProcessExQueue();
            q.Add(s);
            s = new ProcessEx();
            s.SetupProcess(@"C:\MyP\MBN\Dev\Test\Hello\bin\Debug\Hello.exe", "process 1");
            q.Add(s);
            s = new ProcessEx();
            s.SetupProcess(@"C:\MyP\MBN\Dev\Test\Hello\bin\Debug\Hello.exe", "process 2");
            q.Add(s);
            Thread t = new Thread(q.StartFirstProcesses);
            t.Start();
            Console.ReadKey();
        }
    }
    class ProcessExQueue
    {
        private List<ProcessEx> Servers = new List<ProcessEx>();
        public int MaxConcurrent { get; set; }
        public int Delay { get; set; }
        byte _running = 0;
        public ProcessExQueue()
        {
            MaxConcurrent = 4;
            Delay = 60000;
        }
        public void Add(ProcessEx Server)
        {
            Servers.Add(Server);
            Server.Exited += cmd_Exited;
            Server.Started += cmd_Started;
        }
        private bool RunNextProcess()
        {
            bool retval = false;
            if (Servers.Count > 0)
            {
                ProcessEx ToRun = Servers[0];
                Servers.Remove(ToRun);
                retval = ToRun.StartProcess();
                if (retval)
                    lock (this)
                    {
                        _running++;
                    }
            }
            Console.WriteLine("Thread Id {0} will sleep...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(Delay);
            Console.WriteLine("Thread Id {0} woke up", Thread.CurrentThread.ManagedThreadId);
            return retval;
        }
        public void StartFirstProcesses()
        {
            while (Servers.Count > 0 && _running <= MaxConcurrent)
            {
                RunNextProcess();
            }
        }
        private void cmd_Exited(object sender, EventArgs e)
        {
            lock (this)
            {
                _running--;
            }
            Console.WriteLine("Queue: process exited {0}.", ((ProcessEx)sender).GetPID());
           if(Servers.Count > 0 && _running <= MaxConcurrent)
            {
                RunNextProcess();
            }
        }
        private void cmd_Started(object sender, EventArgs e)
        {
             Console.WriteLine("Queue: process started {0}", ((ProcessEx)sender).GetPID());
        }
    }
    class ProcessEx
    {
        public bool IsRunning
        {
            get
            {
                return pIsRunning;
            }
        }
        private bool pIsRunning = false;
        public delegate void OutputEventHandler(ProcessEx sender, string Output, bool IsError);
        public delegate void StatusEventHandler(ProcessEx sender, EventArgs e);
        public event StatusEventHandler Started;
        public event StatusEventHandler Exited;
        private Process cmd;
        public int GetPID()
        {
            return cmd.Id;
        }
        public bool StartProcess()
        {
            bool retval = false;
            if (cmd.Start())
            {
                pIsRunning = true;
                retval = true;
                Console.WriteLine("Running  {0} {1}", cmd.StartInfo.FileName, cmd.StartInfo.Arguments);
                Console.WriteLine("Process Id {0}", cmd.Id);
                if (Started != null)
                    Started(this, null);
            }
            return retval;
        }
        public void KillProcess()
        {
            if (IsRunning)
            {
                cmd.Kill();
            }
        }
        public void SetupProcess(string program, string args)
        {
            // https://msdn.microsoft.com/en-us/library/h6ak8zt5(v=vs.110).aspx
            cmd = new Process();
            cmd.StartInfo.FileName = program;
            cmd.StartInfo.Arguments = args;
            cmd.EnableRaisingEvents = true;
            //cmd.StartInfo.Verb = "Print";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.Exited += new EventHandler(cmd_Exited);
        }
        private void cmd_Exited(object sender, EventArgs e)
        {
            pIsRunning = false;
            if (Exited != null)
            {
                Console.WriteLine("thread {0} received exit signal", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Process {0} exited. notfying queue...", ((Process)sender).Id);
                Exited(this, null); // signal the queue to run the next process
            }
        }
    }
}
