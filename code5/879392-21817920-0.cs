    class TimeRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeRange ()
	    {
	    }
        public TimeRange(TimeSpan todayStart, TimeSpan todayEnd)
        {
            Start = DateTime.Today + todayStart;
            End = DateTime.Today + todayEnd;
        }
    }
