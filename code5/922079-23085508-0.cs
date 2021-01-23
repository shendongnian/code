    Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
    
    for (int i = 0; i < 1440; i++)
    {
        if ((i >= 480 && i < 790) || (i >= 1050 && i < 1170)
            anyLisy.Add(0);
        else if ((i >= 790 && i < 1050)
            anyLisy.Add(1);                                       
        else
            anyLisy.Add(2);
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
