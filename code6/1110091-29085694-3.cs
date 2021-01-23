    public static class PreciseClock
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;
        private static readonly Stopwatch Stopwatch = Stopwatch.StartNew();
        public static DateTime GetCurrentUtcTime()
        {
            return StartTime + Stopwatch.Elapsed;
        }
    }
