    public class QuartzRetryJobListner : IJobListener
    {
        public string Name => GetType().Name;
        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default) => await Task.CompletedTask;
        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default) => await Task.CompletedTask;
    
    
        public async Task JobWasExecuted(
    	    IJobExecutionContext context,
    	    JobExecutionException jobException,
    	    CancellationToken cancellationToken = default)
        {
            if (jobException == null) return;
            
            // Create and schedule new trigger
            ITrigger retryTrigger = TriggerBuilder.Create()
                 .StartAt(DateTime.UtcNow)
                 .Build();
    
            await context.Scheduler.ScheduleJob(context.JobDetail, new[] { retryTrigger }, true);
        }
    }
