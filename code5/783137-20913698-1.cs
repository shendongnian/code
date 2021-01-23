       System.Timers.Timer _timer;
        DateTime _scheduleTime; 
        public WinService()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
            _scheduleTime = DateTime.Today.AddDays(1).AddHours(7); // Schedule to run once a day at 7:00 a.m.
        }
        protected override void OnStart(string[] args)
        {           
            // For first time, set amount of seconds between current time and schedule time
            _timer.Enabled = true;
            _timer.Interval = _scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;                                          
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        }
        protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 1. Process Schedule Task
            // ----------------------------------
            // Add code to Process your task here
            // ----------------------------------
            // 2. If tick for the first time, reset next run to every 24 hours
            if (_timer.Interval != 24 * 60 * 60 * 1000)
            {
                _timer.Interval = 24 * 60 * 60 * 1000;
            }  
        }
      
