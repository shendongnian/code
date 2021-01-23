    IJobDetail jobDetail = JobBuilder.Create<ReportJob>()
        .WithIdentity("theJob")
        .Build();
    ITrigger everydayTrigger = TriggerBuilder.Create()
        .WithIdentity("everydayTrigger")
        // fires 
        .WithCronSchedule("0 0 12 1/1 * ?")
        // start immediately
        .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
        .Build();
    ITrigger yearlyTrigger = TriggerBuilder.Create()
        .WithIdentity("yearlyTrigger")
        // fires 
        .WithCronSchedule("0 0 12 1 1 ? *")
        // start immediately
        .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
        .Build();
    var dictionary = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();
    dictionary.Add(jobDetail, new Quartz.Collection.HashSet<ITrigger>()
                                {
                                    everydayTrigger,
                                    yearlyTrigger
                                });
    sched.ScheduleJobs(dictionary, true);
