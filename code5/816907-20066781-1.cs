    internal class MyScheduler : TaskScheduler
    {
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }
        protected override void QueueTask(Task task)
        {
            base.TryExecuteTask(task);
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            base.TryExecuteTask(task);
            return true;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Main");
        Task.Factory.StartNew(() => ThisShouldBeExecutedSynchronously(), CancellationToken.None, TaskCreationOptions.None, new MyScheduler());
    }
