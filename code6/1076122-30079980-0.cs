    class RunActionJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var action = context.MergedJobDataMap["action"] as Action;
            action();
        }
    }
    public static JobBuilder ActionJob(Action action)
    {
        return JobBuilder
            .Create<RunActionJob>()
            .SetJobData(new JobDataMap
            {
                {"action", action}
            });
    }
    // Usage:
    var job = ActionJob(() => Console.WriteLine("task 1..."))
        .WithIdentity("task1", "group1")
        .Build();
