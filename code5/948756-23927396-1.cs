     static  System.Timers.Timer _timer;
        static string _ScheduledRunningTime ="6:00 AM";
    
        public Service1()
            {
            InitializeComponent();
            }
    
        protected override void OnStart(string[] args)
            {
            try
                {
                _timer = new System.Timers.Timer();
                _timer.Interval = 1 * 60 * 1000;//Every one minute
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                _timer.Start();
                }
            catch (Exception ex)
                {
                //Displays and Logs Message
                _loggerDetails.LogMessage = ex.ToString();
                _writeLog.LogDetails(_loggerDetails.LogLevel_Error, _loggerDetails.LogMessage);
                }
            }
    
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
            //Displays and Logs Message
            _loggerDetails.LogMessage = "timer_Elapsed method at :"+DateTime.Now ;
            _writeLog.LogDetails(_loggerDetails.LogLevel_Info, _loggerDetails.LogMessage);
    
            string _CurrentTime=String.Format("{0:t}", DateTime.Now);
            if (_CurrentTime == _ScheduledRunningTime)
                {
                ExtractDataFromSharePoint();
                }
            }
