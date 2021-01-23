    public static FluentAutomationExtensions
    {
        public statis StopWatch sw = new StopWatch();
        public static I StartTimer(this I) { sw.Reset(); sw.Start();  }
        public static I StopTimer(this I) { sw.Stop(); Trace.Write(sw.ElapsedMilliseconds); }
    }
