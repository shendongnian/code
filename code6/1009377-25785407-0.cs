        public static List<JobTimer> _timers;
        public class JobTimer : System.Windows.Forms.Timer
        {
            private int IntJobID;
            public int JobID
            {
                get { return IntJobID; }
                set { IntJobID = value; }
            }
        }
        public static void CreateTimer(int JobID)
        {
            if (_timers == null)
            {
                _timers = new List<JobTimer>();
            }
            JobTimer ControlJobTimer = new JobTimer();
            ControlJobTimer.Enabled = true;
            ControlJobTimer.JobID = JobID;
            ControlJobTimer.Interval = 30000;
            ControlJobTimer.Tick += new EventHandler(JobTimer_Tick);
            ControlJobTimer.Start();
            _timers.Add(ControlJobTimer);
        }
