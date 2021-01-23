    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        System.IO.TextWriter file;
        public Service1()
        {
            // Uncomment this line to launch the debugger when starting the service.
            //System.Diagnostics.Debugger.Launch();
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            file = new StreamWriter("C:\\logfile.txt", true);
            file.WriteLine("Service Started");
            timer.AutoReset = true;
            timer.Interval  = 1000;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        protected override void OnStop()
        {
            timer.Stop();
            timer.Dispose();
            file.WriteLine("Service Stopped");
            file.Close();
        }
        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            file.WriteLine("CPU Usage : " + System.DateTime.Now);
        }
    }
