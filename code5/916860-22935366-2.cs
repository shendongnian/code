    namespace Program
    {
        static class Program
        {
            public static bool Stopped = false;
            [STAThread]
            static void Main(string[] args)
            {
                Interactive.Initialize();
                Interactive.OnStopped += new Interactive.StopedDelegate(OnStopped);
                Interactive.Title = Path.GetFileNameWithoutExtension(
                    Assembly.GetExecutingAssembly().Location);
    
                if (args.Length == 0) Interactive.Run(RunProc);
                else if (args[0] == "-svc") ServiceBase.Run(new Service());
            }
            public static void RunProc() { yourConsoleMain(); }
            public static void OnStopped() { Stopped = true; exitFromMain(); }
        }
    
        public class Service : ServiceBase
        {
            public static string Name = Path.GetFileNameWithoutExtension(
                Assembly.GetExecutingAssembly().Location);
            public static string CmdLineSwitch = "-svc";
            public static ServiceStartMode StartMode = ServiceStartMode.Automatic;
            public static bool DesktopInteract = true;
            public bool Stopped = false;
            public Service() { ServiceName = Name; }
            public void Start() { OnStart(null); }
            protected override void OnStart(string[] args)
            {
                System.Diagnostics.EventLog.WriteEntry(
                    ServiceName, ServiceName + " service started.");
                Thread thread = new Thread(MainThread);
                thread.Start();
            }
            protected override void OnStop()
            {
                System.Diagnostics.EventLog.WriteEntry(
                    ServiceName, ServiceName + " service stopped.");
                Stopped = true;
                Application.Exit();
            }
            private void MainThread()
            {
                Interactive.Run(Program.RunProc);
                if (!Stopped) Stop();
            }
        }
    }
