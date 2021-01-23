        class ProcessExQueue
        {
            public int MaxConcurrent { get; set; }
            public int Delay { get; set; }
            public Action Done;
            private List<Timer> _timers;
    
            private List<ProcessEx> Servers = new List<ProcessEx>();
            byte _running = 0;
            private DateTime _lastStart;
    
            public ProcessExQueue()
            {
                MaxConcurrent = 4;
                Delay = 15000;
                _timers = new List<Timer>();
            }
    
            public void Add(ProcessEx Server)
            {
                Servers.Add(Server);
                Server.Exited += cmd_Exited;
                Server.Started += cmd_Started;
            }
    
            public void RunProcessTimer(int delay)
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(DoTask);
                timer.Interval = delay;
                timer.AutoReset = false; // only first time
                timer.Start();
                _timers.Add(timer);
                Console.WriteLine("timer started with delay {0} @ {1} ", delay, DateTime.Now);
            }
    
            void DoTask(object source, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("timer call @ {0}", DateTime.Now);
                lock (this)
                {
                    if (Servers.Count > 0 && _running <= MaxConcurrent)
                    {
                        ProcessEx ToRun = Servers[0];
                        ToRun.Starter = (Timer)source;
                        Servers.Remove(ToRun);
                        bool success = ToRun.StartProcess();
                        if (success)
                            _running++;
                    }
                    else
                    {
                        Console.WriteLine("nothing started, queue size {0} running {1}", Servers.Count, _running);
                    }
                }
            }
    
            public void StartFirstProcesses()
            {
                for (int i = 0; i < Servers.Count; i++)
                {
                    RunProcessTimer(i == 0 ? 1000 : Delay*(i));
                }
            }
    
            private void cmd_Exited(object sender, EventArgs e)
            {
                Console.WriteLine("Queue: process exited {0}.", ((ProcessEx)sender).GetPID());
    
                // find the timer and get rid of it;
                //TODO
    
                Timer found = _timers.FirstOrDefault(t => t == ((ProcessEx)sender).Starter);
                if (found != null)
                {
                    found.Enabled = false;
                }
    
                lock (this)
                {
                    _running--;
                }
    
                if (Servers.Count == 0) // no more processes to run
                {
                    Console.WriteLine("No more processes to run.  some threads may be asleep");
                    if (_running == 0)
                    {
                        Console.WriteLine("disarming all timers");
                        _timers.ForEach(t=> t.Enabled=false);  
                        Done();
                    }
                }
                else
                {
                    if (Servers.Count > 0 && _running <= MaxConcurrent)
                    {
                        TimeSpan tspan = (DateTime.Now - _lastStart);
                        RunProcessTimer(tspan.Milliseconds < Delay?Delay - tspan.Milliseconds:1);
                    }
                }
            }
    
            private void cmd_Started(object sender, EventArgs e)
            {
                Console.WriteLine("Queue: process started {0}", ((ProcessEx)sender).GetPID());
                _lastStart = DateTime.Now;
            }
        }
    
        class ProcessEx
        {
            public Timer Starter { get; set; }
    
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
    
    // usage
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
    
                q.Done = () => Console.WriteLine("Done!");
    
                q.StartFirstProcesses();
                /*
                Thread t = new Thread(q.StartFirstProcesses);
                t.Start();
                */
                Console.ReadKey();
            }
        }
    // sample process
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Count() > 0)
                {
                    Console.WriteLine(Process.GetCurrentProcess().Id);
                    Thread.Sleep(5000);
                    Console.WriteLine("exiting... press any key");
                    Console.ReadKey();
                }
            }
        }
