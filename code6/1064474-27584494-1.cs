    static void Main(string[] args)
    {
        TaskFactory factory = new TaskFactory(new LimitedExecutionRateTaskScheduler(5, 5)); // 5 per second, 5 max executing
        List<string> symbolsToCheck = new List<string>() { "GOOG", "AAPL", "MSFT" };
        for (int i = 0; i < 5; i++)
            symbolsToCheck.AddRange(symbolsToCheck);
        foreach (string symbol in symbolsToCheck)
        {
            factory.StartNew(() =>
            {
                Console.WriteLine("[{0:HH:mm:ss}] [{1}] Doing {2}..", DateTime.Now, Thread.CurrentThread.ManagedThreadId, symbol);
                Thread.Sleep(5000);
                Console.WriteLine("[{0:HH:mm:ss}] [{1}] {2} is done", DateTime.Now, Thread.CurrentThread.ManagedThreadId, symbol);
            });
        }
        Console.Read();
    }
    public class LimitedExecutionRateTaskScheduler : TaskScheduler
    {
        private ConcurrentQueue<Task> _pendingTasks = new ConcurrentQueue<Task>();            
        private readonly object _taskLocker = new object();
        private List<Task> _executingTasks = new List<Task>();
        private readonly int _maximumConcurrencyLevel = 5;
        private Timer _doWork = null;
        public LimitedExecutionRateTaskScheduler(double requestsPerSecond, int maximumDegreeOfParallelism)
        {
            _maximumConcurrencyLevel = maximumDegreeOfParallelism;
            long frequency = (long)(1000.0 / requestsPerSecond);
            _doWork = new Timer(ExecuteRequests, null, frequency, frequency);
        }
        public override int MaximumConcurrencyLevel
        {
            get
            {
                return _maximumConcurrencyLevel;
            }
        }
        protected override bool TryDequeue(Task task)
        {
            return base.TryDequeue(task);
        }
        protected override void QueueTask(Task task)
        {
            _pendingTasks.Enqueue(task);
        }
        private void ExecuteRequests(object state)
        {
            Task queuedTask = null;
            int currentlyExecutingTasks = 0;
            lock (_taskLocker)
            {
                for (int i = 0; i < _executingTasks.Count; i++)
                    if (_executingTasks[i].IsCompleted)
                        _executingTasks.RemoveAt(i--);
                currentlyExecutingTasks = _executingTasks.Count;
            }
                
            if (currentlyExecutingTasks == MaximumConcurrencyLevel)
                return;
            if (_pendingTasks.TryDequeue(out queuedTask) == false)
                return; // no work to do
            lock (_taskLocker)
                _executingTasks.Add(queuedTask);
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
