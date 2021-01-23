    public class MvcApplication : System.Web.HttpApplication
    {
        [ThreadStatic]
        private static Stopwatch stopwatch;
        protected void Application_Start()
        {
            //...
        }
        protected void Application_BeginRequest()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        protected void Application_EndRequest()
        {
            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;
            //log time...
            stopwatch.Reset();
        }
    }
