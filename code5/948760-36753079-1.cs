     protected override void OnStart(string[] args)
        {
            // Pass in the time you want to start and the interval
            StartTimer(new TimeSpan(6, 0, 0), new TimeSpan(24, 0, 0));
        }
        protected void StartTimer(TimeSpan scheduledRunTime, TimeSpan timeBetweenEachRun) {
            // Initialize timer
            double current = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double scheduledTime = scheduledRunTime.TotalMilliseconds;
            double intervalPeriod = timeBetweenEachRun.TotalMilliseconds;
            // calculates the first execution of the method, either its today at the scheduled time or tomorrow (if scheduled time has already occured today)
            double firstExecution = current > scheduledTime ? intervalPeriod + (intervalPeriod - current) : scheduledTime - current;
            // create callback - this is the method that is called on every interval
            TimerCallback callback = new TimerCallback(RunXMLService);
            // create timer
            _timer = new Timer(callback, null, Convert.ToInt32(firstExecution), Convert.ToInt32(intervalPeriod));
       
        }
        public void RunXMLService(object state) {
            // Code that runs every interval period
        }
