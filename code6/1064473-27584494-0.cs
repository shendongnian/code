    static void Main(string[] args)
    {
        TaskFactory factory = new TaskFactory(new LimitedExecutionRateTaskScheduler(1)); // 1 per second
        List<string> symbolsToCheck = new List<string>() { "GOOG", "AAPL", "MSFT" };            
            
        foreach (string symbol in symbolsToCheck)
        {
            factory.StartNew(() =>
            {
                Console.WriteLine("[{0:HH:mm:ss}] Doing {1}..", DateTime.Now, symbol);
            });
        }
        Console.Read();
    }
    public class LimitedExecutionRateTaskScheduler : TaskScheduler
    {
        private ConcurrentQueue<Task> _pendingTasks = new ConcurrentQueue<Task>();
        private Timer _doWork = null;
        public LimitedExecutionRateTaskScheduler(double requestsPerSecond)
        {
            long frequency = (long)(1000.0 / requestsPerSecond);
            _doWork = new Timer(ExecuteRequests, null, frequency, frequency);
        }
        protected override void QueueTask(Task task)
        {
            _pendingTasks.Enqueue(task);
        }
            
        private void ExecuteRequests(object state)
        {
            Task queuedTask = null;
            if (_pendingTasks.TryDequeue(out queuedTask) == false)
                return; // no work to do
            base.TryExecuteTask(queuedTask);
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false; // not properly implemented just to complete the class
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return new List<Task>(); // not properly implemented just to complete the class
        }
    }
