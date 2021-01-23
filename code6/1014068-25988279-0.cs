    var jobName = "MyJob";
    var jobKey = new JobKey(jobName);
    s.ScheduleQuartzJob(q =>
               q.WithJob(() => JobBuilder.Create<MyJob>()
                    .WithIdentity(jobKey).Build())
                .AddTrigger(() => TriggerBuilder.Create()
                    .WithSimpleSchedule(builder => builder
                        .WithIntervalInSeconds(5)
                    .Build())
    var listener = new RepeatAfterCompletionJobListener(TimeSpan.FromSeconds(5));
    var listenerManager = ScheduleJobServiceConfiguratorExtensions
          .SchedulerFactory().ListenerManager;
    listenerManager.AddJobListener(listener, KeyMatcher<JobKey>.KeyEquals(jobKey));
