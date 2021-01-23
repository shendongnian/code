    var counter = new PerformanceCounter{};
    counter.CategoryName = "Process";
    counter.CounterName = "% Processor Time";
    counter.InstanceName = someProcessName;
    try
    {
       if ( PerformanceCounterCategory.InstanceExists( someProcessName, "Process" ) )
       {
           // For any reason the process terminates EXACTLY at this point
           counter.NextValue();
       }
    }
    catch(InvalidOperationException error)
    {
       //deal with exception
    }
