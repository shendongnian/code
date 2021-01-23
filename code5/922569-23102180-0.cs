    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new { Thread.CurrentThread.ManagedThreadId });
            var task = Task.Factory.StartNew(
                () => Console.WriteLine(new { 
                    Thread.CurrentThread.IsThreadPoolThread,
                    Thread.CurrentThread.ManagedThreadId}),
                CancellationToken.None,
                // hide the scheduler from inner tasks
                TaskCreationOptions.HideScheduler,
                NewThreadTaskScheduler.Scheduler);
            task.Wait();
        }
    }
    class NewThreadTaskScheduler : TaskScheduler
    {
        public static readonly NewThreadTaskScheduler Scheduler = 
            new NewThreadTaskScheduler();
        NewThreadTaskScheduler()
        {
        }
        protected override void QueueTask(Task task)
        {
            var thread = new Thread(() =>
            {
                base.TryExecuteTask(task);
            });
            thread.IsBackground = true;
            thread.Start();
        }
        protected override bool TryExecuteTaskInline(
            Task task, 
            bool taskWasPreviouslyQueued)
        {
            return false;
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return null;
        }
        public override int MaximumConcurrencyLevel { 
            get { return Int32.MaxValue; } }
    }
