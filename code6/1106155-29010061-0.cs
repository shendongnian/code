        private static readonly BackgroundWorker Worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        private static readonly AutoResetEvent ResetEvent = new AutoResetEvent(false);
        private static bool success;
      	private static void Main()
        {
            Worker.DoWork += worker_DoWork;
            Worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            var timer = new System.Timers.Timer(60000);
            timer.Elapsed += TimerElapsed;
            timer.Enabled = true;
            Worker.RunWorkerAsync();
            ResetEvent.WaitOne();
            Logging.Log(SeverityTypeEnum.Information, (success)? "Mission succsessful" : "We have a problem Houston");
        }
        
        static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logging.Log(SeverityTypeEnum.Information, "Thankyou and goodnight");
            success = true;
        }
        static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Logging.Log(SeverityTypeEnum.Information, "Time please Gentlemen, time!");
            ResetEvent.Set();  // aborts worker
        }
        private static void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
        	// create SqlCommand, SqlDataAdapter and call Fill as before
        }
