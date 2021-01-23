    stopwatch sw = new stopwatch;
    sw.Start();
    // do something here that you want to measure
    sw.Stop();
    // Get the elapsed time as a TimeSpan
    TimeSpan ts = sw.Elapsed;
    // Format and display the TimeSpan
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);
    Console.WriteLine("That took: {0}", elapsedTime);
