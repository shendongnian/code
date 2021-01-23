    public class JobSchedulerPlugin : ISchedulerPlugin, IJob
    {
            //Entry point for plugin, quartz server runs when it starts
            public void Initialize(string pluginName, IScheduler sched)
            {
                Name = pluginName;
                Scheduler = sched;
            }
        
            //Runs after Initialize()
            public void Start()
            {
                    //schedule plugin as a job
                JobDataMap jobData = new JobDataMap();
                jobData["ConnectionString"] = ConnectionString;
        
                IJobDetail job = JobBuilder.Create(this.GetType())
                    .WithDescription("Job to rescan jobs from SQL db")
                    .WithIdentity(new JobKey(JobInitializationPluginJobName, JobInitializationPluginGroup))
                    .UsingJobData(jobData)
                    .Build();
        
                 TriggerKey triggerKey = new TriggerKey(JobInitializationPluginJobTriggerName, JobInitializationPluginGroup);
        
                 ITrigger trigger = TriggerBuilder.Create()
                     .WithCronSchedule(ConfigFileCronExpression)
                     .StartNow()
                     .WithDescription("trigger for sql job loader")
                     .WithIdentity(triggerKey)
                     .WithPriority(1)
                     .Build();
        
                 Scheduler.ScheduleJob(job, trigger);
            }
    }
