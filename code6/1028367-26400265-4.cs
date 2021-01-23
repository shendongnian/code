    public static FluentAutomationExtensions
    {
        public statis StopWatch sw = new StopWatch();
        public static IActionSyntaxProvider StartTimer(this IActionSyntaxProvider) { sw.Reset(); sw.Start();  }
        public static IActionSyntaxProvider BaseFluentTest StopTimer(this IActionSyntaxProvider) { sw.Stop(); Trace.Write(sw.ElapsedMilliseconds); }
    }
