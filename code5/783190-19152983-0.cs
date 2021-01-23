    public class Report
    {
        public int USERID { get; set; }
        public DateTime DateToCal { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        private TimeSpan? _intime;
        public TimeSpan Intime {
            get { return _intime ?? new TimeSpan(0); }  
            set { _intime = value; }
        }
        private TimeSpan? _outTime;
        public TimeSpan OutTime
        {
            get { return _outTime ?? new TimeSpan(0); }
            set { _outTime = value; }
        }
    }
