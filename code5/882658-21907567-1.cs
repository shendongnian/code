    public class TimeProvider : ITimeProvider
    {
        private static ITimeProvider _instance = new TimeProvider();
        private TimeProvider() { }
        public static ITimeProvider Instance 
        {
            get { return _instance; }
            set { _instance = value; } // allows you to set mock
        }
        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }
    }
