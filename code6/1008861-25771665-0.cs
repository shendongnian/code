    public class ActivityGridModel
    {
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; }
        public string Notes { get; set; }
        public string EnteredBy { get; set; }
        private long _timeSpent;
        public long TimeSpent
        { 
           get
           {
              return _timeSpent;
           } 
           set 
           {
              _timeSpent = value;
              var tsSpent = new TimeSpan(_timeSpent);
              Days = tsSpent .Days;
              Hours = tsSpent .Hours;
              Minutes = tsSpent .Minutes;
           }
        }
        public int Days { get; private set; //readonly for class clients }
        public int Hours { get; private set; //readonly for class clients}
        public int Minutes { get; private set; //readonly for class clients}
    }
