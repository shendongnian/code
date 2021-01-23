    public class RepeatAfterCompletionJobListener : IJobListener
    {
        private readonly TimeSpan interval;
        
        public RepeatAfterCompletionJobListener(TimeSpan interval)
        {
            this.interval = interval;
        }
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }
        public void JobToBeExecuted(IJobExecutionContext context)
        {
        }
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
           string triggerKey = context.JobDetail.Key.Name + "trigger";
            var trigger = TriggerBuilder.Create()
                    .WithIdentity(triggerKey)
                    .StartAt(new DateTimeOffset(DateTime.UtcNow.Add(interval)))
                    .Build();
            context.Scheduler.RescheduleJob(new TriggerKey(triggerKey), trigger);
        }
        public string Name
        {
            get
            {
                return "RepeatAfterCompletionJobListener";
            }
        }
    }
