    var jobKey = "myJobKey";
    var schedule = new StdSchedulerFactory().GetScheduler();
    listener = new
       RepeatAfterCompletionJobListener(TimeSpan.FromSeconds(5));
   
    schedule.ListenerManager.AddJobListener
             (listener, KeyMatcher<JobKey>.KeyEquals(new JobKey(jobKey)));
    var job = JobBuilder.Create(MyJob)
                    .WithIdentity(jobKey)
                    .Build();
    // Schedule the job to start in 5 seconds to give the service time to initialise
    var trigger = TriggerBuilder.Create()
                    .WithIdentity(CreateTriggerKey(jobKey))
                    .StartAt(DateTimeOffset.Now.AddSeconds(5))
                    .Build();
    schedule.ScheduleJob(job, trigger);
