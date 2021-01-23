    using Quartz;
    using Quartz.Impl;
    IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
    scheduler.Start();
    
    IJobDetail integrationJob = JobBuilder.Create<IntegrationJob>().Build();
    ITrigger integrationTrigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(300).RepeatForever()).Build();
    scheduler.ScheduleJob(integrationJob, integrationTrigger);
    public class IntegrationJob : Ijob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Write code for job
        }
    }
