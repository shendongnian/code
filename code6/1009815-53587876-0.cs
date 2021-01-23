    public static void SetSchedule<T>(this IScheduler source, TimeSpan minWaitSeconds, string cron)
       where T : IJob
    {
       var jobName = typeof(T).Name;
    
       var triggerKey = new TriggerKey($"{jobName} Trigger");
    
       DateTimeOffset minNextTime = DateTime.UtcNow.AddSeconds(2) + minWaitSeconds;
    
       var trigger = TriggerBuilder.Create()
                                   .WithIdentity(triggerKey)
                                   .StartAt(minNextTime)
                                   .WithCronSchedule(cron)
                                   .Build();
           
       var jobKey = new JobKey(jobName);
    
       var job = JobBuilder.Create<T>()
                           .WithIdentity(jobKey)
                           .Build();
    
       source.ScheduleJob(job, trigger);
    }
