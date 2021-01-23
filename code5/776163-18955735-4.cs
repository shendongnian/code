    protected void Application_BeginRequest()
    {
        var stopwatch = new Stopwatch();
        stopwatch = new Stopwatch();
        stopwatch.Start();
        HttpContext.Current.Items.Add("RequestStopwatch", stopwatch);
    }
    protected void Application_Error(object sender, EventArgs e)
    {
        //...
        if (HttpContext.Current.Items["RequestStopwatch"] != null)
        {
            var stopwatch = (Stopwatch)HttpContext.Current.Items["RequestStopwatch"];
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            //log time...
            HttpContext.Current.Items.Remove("RequestStopwatch");
        }
        //...
    }
