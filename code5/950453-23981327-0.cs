    interface IClock
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
    
    class SystemClock : IClock
    {
        public DateTime Now { get { return DateTime.Now; } }
        public DateTime UtcNow { get { return DateTime.UtcNow ; } }
    }
    
    class TestDoubleClock : IClock
    {
        public DateTime Now { get { return whateverTime; } }
        public DateTime UtcNow { get { return whateverTime ; } }
    }
