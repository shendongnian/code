    ISchedulerFactory sf = new StdSchedulerFactory(properties);
    IScheduler sched = sf.GetScheduler();
                
    var jobDetail = JobBuilder.Create<NoOpJob>().Build();
    
    var key = new TriggerKey("trigger-name", "trigger-group");
    if (sched.GetTrigger(key) == null)
    {
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(key)
            .StartAt(DateBuilder.EvenHourDate(DateTimeOffset.UtcNow))
            .WithSimpleSchedule(x => x
                .RepeatForever()
                .WithInterval(TimeSpan.FromMinutes(5)))
            .Build();
    
        sched.ScheduleJob(jobDetail, trigger);
    }
