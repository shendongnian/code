    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            // Find and update data here
        }
    }
    // define the job and tie it to our MyJobclass
    IJobDetail job = JobBuilder.Create<MyJob>()
        .WithIdentity("myJob")
        .Build();
    
    // Trigger the job to run at midnight every day
    ITrigger trigger = TriggerBuilder.Create()
        .WithIdentity("myTrigger")
        .StartAt(DateBuilder.AtHourOfDay(0))
        .WithSimpleSchedule(x => x.WithIntervalInHours(24).RepeatForever())
        .Build();
    // Tell quartz to schedule the job using our trigger
    scheduler.ScheduleJob(job, trigger);
