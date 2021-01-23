    public static Dictionary<Process, double> GetCpuUsages(Process[] processes)
    {
        // One performance counter is required per process
        PerformanceCounter[] counters = new PerformanceCounter[processes.Length];
    
        // Instantiate a new counter per process
        for(int i = 0; i < processes.Length; i++)
        {
            PerformanceCounter processorTimeCounter = new PerformanceCounter(
                "Process",
                "% Processor Time",
                processes[i].ProcessName);
            // Call NextValue once to have a reference value
            processorTimeCounter.NextValue();
            // Add it to the array
            counters[i] = processorTimeCounter;
        }
    
        // Sleep one second to have accurate measurement
        Thread.Sleep(1000); 
        // Here we store the processes along with their measurement in a dictionary
        Dictionary<Process, double> cpuUsageDictionary = new Dictionary<Process, double>();
    
        for (int i = 0; i < counters.Length; i++)
        {
            // And now we add one key/value pair per process along with its cpu time measurement
            cpuUsageDictionary.Add(processes[i],  counters[i].NextValue());
        }
    
        return cpuUsageDictionary;
    }
