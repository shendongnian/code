    public class myApp
    {   
        public System.Diagnostics.EventLog myEventLog { get; set; }
	    private Thread appThread;
        public int TimerIntervalSeconds {get; set;}
        
        public void Start()
        {
            appThread = new Thread(new ThreadStart(WorkThreadFunction));
            appThread.Start();
        }
        public void Stop()
        {
            if (appThread != null)
            {
                appThread.Abort();
                appThread.Join();
            }
		}
        private void WorkThreadFunction()
        {
            // Loop until the thread gets aborted
            try
            {
                while (true)
                {
                    WriteToDatabase();
                    
                    // Sleep for TimerIntervalSeconds
                    Thread.Sleep(TimerIntervalSeconds * 1000);
                }
            }
            catch (ThreadAbortException)
            {
                myEventLog.WriteEntry("INFO: Thread aborted", System.Diagnostics.EventLogEntryType.Warning);
            }
            catch (Exception e)
            {
                myEventLog.WriteEntry("Error in Execute: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
