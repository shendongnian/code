    var list = new List<Type>();
    list.Add(typeof(BillingJob));
    list.Add(typeof(MaintenanceUrlTriggerJob));
    
    var jobId = 0;
    foreach (var jobType in list)
    {
        jobId++;
        
        var method = typeof(QuartzSchedulerClass).GetMethod("ScheduleJob");
        var generic = method.MakeGenericMethod(jobType);
        generic.Invoke(this, (Other Params));
    }
