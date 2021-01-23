    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    // run your test here...
    stopWatch.Stop();
    
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    Console.WriteLine("RunTime " + elapsedTime);
