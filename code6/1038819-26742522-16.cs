    private static readonly Lazy<TaskScheduler> Scheduler = new Lazy<TaskScheduler>(
        () => new WorkStealingTaskScheduler(16));
    public static TaskScheduler Default
    {
        get
        {
            return Scheduler.Value;
        }
    }
    public static TaskScheduler CreateNewOrderedTaskScheduler()
    {
        return new QueuedTaskScheduler(Default, 1);
    }
