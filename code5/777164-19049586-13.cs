    public class TimeRange
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string StartString { get { return new DateTime(Start.Ticks).ToString("hh:mm tt"); } }
        public string EndString { get { return new DateTime(End.Ticks).ToString("hh:mm tt"); } }
        public TimeRange(int starthour, int startminute, int endhour, int endminute)
        {
            Start = new TimeSpan(0, starthour, startminute, 0);
            End = new TimeSpan(0, endhour, endminute, 0);
        }
    }
