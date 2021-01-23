    public static class QuartzExtensions
    {
        public static void RepeatJobAfterFall(this IScheduler scheduler, IJobDetail job)
        {
            scheduler.ListenerManager.AddJobListener(
                new QuartzRetryJobListner(),
                KeyMatcher<JobKey>.KeyEquals(job.Key));
        }
    }
