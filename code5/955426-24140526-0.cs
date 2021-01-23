    if (!PerformanceCounterCategory.Exists("Processor Information"))
    {
        CounterCreationDataCollection counter = new CounterCreationDataCollection();
    
        CounterCreationData data = new CounterCreationData();
        data.CounterName = "% Processor Time";
        totalOps.CounterHelp = "The percentage of time the processor was busy during the sampling interval";
        counter.Add(data);
    
        PerformanceCounterCategory.Create("Processor Information",
                                          "This is a sample", 
                                          PerformanceCounterCategoryType.MultiInstance, 
                                          counter);
    }
