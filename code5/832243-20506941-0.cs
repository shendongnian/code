    HashSet<String> uniqueSources = new HashSet<String>();
    Stopwatch watch = new Stopwatch();
    watch.Start();
    foreach (LoggingMessage mess in bigCollection)
    {
    	uniqueSources.Add(mess.Source);
    }
    Console.WriteLine(String.Format("Time taken for simple add: {0}ms", watch.ElapsedMilliseconds));
    uniqueSources.Clear();
    watch.Restart();
    foreach (LoggingMessage mess in bigCollection)
    {
    	if (!uniqueSources.Contains(mess.Source))
    		uniqueSources.Add(mess.Source);
    }
    Console.WriteLine(String.Format("Time taken for conditional add: {0}ms", watch.ElapsedMilliseconds));
