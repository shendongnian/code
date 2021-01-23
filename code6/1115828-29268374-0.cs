    long TotalMS = 0;
    int EventCount = 0;
    var s = Stopwatch.StartNew();
    while(true)
    {
        if (EventTriggered)
        {
            s.Stop();
            Console.WriteLine("Event detected");
            EventCount++;
            TotalMS+= s.ElapsedMilliseconds;
            AverageMS = TotalMS / EventCount;
            Console.WriteLine("Current average ms: " + AverageMS);
            s.Restart();
        }
    }
