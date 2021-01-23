    public static class TimeProvider
    {        
        private static Func<DateTime> currentTime { get; set; }
        public static DateTime CurrentTime
        {
            get { return currentTime(); }
        }
        public static void SetCurrentTime(Func<DateTime> func)
        {
            currentTime = func;
        }
    }
