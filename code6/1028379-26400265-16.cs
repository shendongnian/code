    using FluentAutomation.Interfaces;
    public static class IExtension
    {
        public static StopWatch sw = new StopWatch();
        public static IActionSyntaxProvider StartTimer(this IActionSyntaxProvider) { sw.Reset(); sw.Start();  }
        public static IActionSyntaxProvider StopTimer(this IActionSyntaxProvider) { sw.Stop(); Trace.Write(sw.ElapsedMilliseconds); }
    }
