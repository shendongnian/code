    public class Worker
    {
        //...
        List<Task> _tasks = new List<Task>();
        public Task Completion { get { return Task.WhenAll(_tasks); } }
        public void Start()
        {
            // Create and start a separate Task for each consumer:
            for (int i = 0; i < _wrkerCount; i++)
            {
                Tasks.Add(Task.Factory.StartNew(_action));
            }
        }
    }
    
    public class OrderlyThreadPool<t> : IDisposable
    {
        //...
        public Task Completion { get { return _worker.Completion; }}
    }
