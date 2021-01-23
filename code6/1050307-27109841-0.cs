    public class Task
    {
        public TimeSpan Duration { get; set; }
        public long Ticks 
        { 
            get { return Duration.Ticks; }
            set { Duration = new TimeSpan(value); }
        }
        // etc.
    }
    string sql = "INSERT INTO Tasks (Duration) values (@Ticks);";
