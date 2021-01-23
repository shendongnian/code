    Timer timer = new Timer(TimerCallback, null, 500, 0);
    Stopwatch stopwatch = Stopwatch.StartNew();
    private void TimerCallback(Object o)
    {
         var entered = stopwatch.ElapsedMilliseconds;
         scan(); 
         scand.WaitOne(); 
         var duration = stopwatch.ElapsedMilliseconds - entered;
         var delay = Math.Max(0, 500 - duration);
         timer.Change(delay, 0);
    }
