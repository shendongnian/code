    public class Broadcast
    {
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeInHours StartTime
        {
            get
            {
                return TimeInHours.FromTimeSpan(StartDateTime.TimeOfDay);
            }
        }
        public TimeInHours EndTime
        {
            get
            {
                return TimeInHours.FromTimeSpan(StartDateTime.Add(Duration).TimeOfDay);
            }
        }
    }
    
    public class Timeslot
    {
        public TimeInHours Start { get; set; }
        public TimeInHours End { get; set; }
        public TimeInHours Duration
        {
            get
            {
                return End.Subtract(Start);
            }
        }
    }
    public class TimeInHours
    {
        public TimeInHours(int value)
        {
            Value = value;
        }
        
        public int Value { get; private set; }
        public TimeInHours Subtract(TimeInHours x)
        {
            return new TimeInHours(Value - x.Value);
        }
        public static TimeInHours FromTimeSpan(TimeSpan ts)
        {
            return new TimeInHours(ts.Hours);
        }
        public static TimeInHours Zero
        {
            get
            {
                return new TimeInHours(0);
            }
        }
        public static bool operator < (TimeInHours t1, TimeInHours t2)
        {
            return t1.Value < t2.Value;
        }
        public static bool operator >(TimeInHours t1, TimeInHours t2)
        {
            return t1.Value > t2.Value;
        }
        public static bool operator <=(TimeInHours t1, TimeInHours t2)
        {
            return t1.Value <= t2.Value;
        }
        public static bool operator >=(TimeInHours t1, TimeInHours t2)
        {
            return t1.Value >= t2.Value;
        }
    }
