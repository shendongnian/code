    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer _timer; 
    
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
    #if DEBUG
            System.Diagnostics.Debugger.Launch(); // This will automatically prompt to attach the debugger if you are in Debug configuration
    #endif
    
            _timer = new System.Timers.Timer(10 * 1000); //10 seconds
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }
    
        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            // Call to run off to a database or do some processing
        }
    
        protected override void OnStop()
        {
            _timer.Stop();
            _timer.Elapsed -= TimerOnElapsed;
        }
    }
