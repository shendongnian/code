    public class Broadcast
    {
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan StartTime
        {
            get
            {
                return StartDateTime.TimeOfDay;
            }
        }
        
        public TimeSpan EndTime
        {
            get
            {
                return StartDateTime.Add(Duration).TimeOfDay;
            }
        }
    }
    
    public class Timeslot
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration
        {
            get
            {
                return End.Subtract(Start);
            }
        }
    }
