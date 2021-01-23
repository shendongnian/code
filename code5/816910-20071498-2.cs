    public class CurrentThreadScheduler : TaskScheduler
    {
        private readonly Dispatcher _dispatcher;
        public CurrentThreadScheduler()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
        }
        protected override void QueueTask(Task task)
        {
            _dispatcher.BeginInvoke(new Func<bool>(() => TryExecuteTask(task)));
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return true;
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }
    }
