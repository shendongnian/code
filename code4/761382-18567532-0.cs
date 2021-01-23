    public class CollectionTask : ICoordinationTask
    {
        private Timer _taskInternalTimer;
        public TimeSpan Timeout { get; set; }
        public event TaskTimedOutEventHandler TaskTimedOut;
        public CollectionTask ()
        {
             _taskInternalTimer = new Timer();
             _taskInternalTimer.Elapsed += OnTaskInternalTimerElapsed;
             _taskInternalTimer.Start();
        }
        private void OnTaskInternalTimerElapsed(object sender, ElapsedArgs args)
        {
            if (_taskInternalTimer.TotalMilisecond >= Timeout)
                  TaskTimedOut(this, new TaskTimedOutEventArgs());
        }
    }
