    PerformanceCounterCategory perfCategory = PerformanceCounterCategory.GetCategories().First(c => c.CategoryName == "Process");
    Console.WriteLine("{0} [{1}]", perfCategory.CategoryName, perfCategory.CategoryType);
    string[] instanceNames = perfCategory.GetInstanceNames();
    
    if (instanceNames.Length > 0)
    {
        foreach (string instanceName in instanceNames)
        {
            Console.WriteLine("    {0}", instanceName);
            PerformanceCounter[] counters = perfCategory.GetCounters(instanceName);
    
            //Go through each processor counter once to get the first value, should just return 0.
            foreach (PerformanceCounter counter in counters)
            {
                if (counter.CounterName == "% Processor Time")
                {
                    counter.NextValue();
                }            
            }
    
            //You need to wait at least 100ms between samples to get useful values, the longer you wait the better the reading.
            Thread.Sleep(150);
    
            foreach (PerformanceCounter counter in counters)
            {
                if (counter.CounterName == "Working Set - Private")
                {
                    Console.WriteLine("        {0} - {1}", counter.CounterName, counter.RawValue, counter.RawValue / 1024);
                }
                if (counter.CounterName == "% Processor Time")
                {
                    Console.WriteLine("        {0} - {1:N1}", counter.CounterName, counter.NextValue());
                }
            }
        }
    }
