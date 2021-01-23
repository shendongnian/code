    partial class MyService : ServiceBase
    {
        private static void Main(string[] args)
        {
            MyService svc = new MyService();
            if (Environment.UserInteractive)
                RunConsole(args, svc);
            else
                Run(svc);
        }
        public MyService()
        {
            InitializeComponent();
        }
        protected static bool KeepRunning { get; set; }
        protected override void OnStart(string[] args)
        {
            StartServiceHost();
        }
        protected override void OnStop()
        {
            StopServiceHost();
        }
        protected override void OnShutdown()
        {
            StopServiceHost();
            base.OnShutdown();
        }
        private static void RunConsole(string[] args, ConverterService svc)
        {
            // need to hold on to Ctrl+C, otherwise StopServiceHost() never gets called
            Console.CancelKeyPress += (sender, e) => ShutDown(svc);
            KeepRunning = true;
            svc.OnStart(args);
            Console.WriteLine("Press <Ctrl+C> to exit.");
            while (KeepRunning)
            {
                Console.ReadLine();
            }
        }
        private void StartServiceHost()
        {
            // start your service
        }
        private void StopServiceHost()
        {
            // stop your service
        }
        private static void ShutDown(MyService svc)
        {
            Console.WriteLine("exiting...");
            svc.OnStop();
            KeepRunning = false;
        }
    }
