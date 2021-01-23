    public static double GetCpuUsage(Process process)
    {
        PerformanceCounter cpuCounter = new PerformanceCounter();
    
        cpuCounter.CategoryName = "Process";
        cpuCounter.InstanceName = process.ProcessName;
        cpuCounter.CounterName = "% Processor Time";
    
        // The first call will always return 0
        cpuCounter.NextValue();
        // That's why we need to sleep 1 second 
        Thread.Sleep(1000);
        // The second call determines, the % of time that the monitored process uses on 
        // % User time for a single processor. 
        // So the limit is 100% * the number of processors you have.
        double processorUsagePercent = cpuCounter.NextValue();
    
        // Hence we need to divide by the number of processors to get the average CPU usage of one process during the time measured
        return processorUsagePercent / Environment.ProcessorCount;
    }
