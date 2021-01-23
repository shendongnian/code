    public class SingleThreadDispatcher
    {
        public long Count;
        private readonly BlockingCollection<Action> _queue = new BlockingCollection<Action>();
        private readonly CancellationTokenSource _cancellation = new CancellationTokenSource();
        public SingleThreadDispatcher()
        {
            var thread = new Thread(Run)
            {
                IsBackground = true,
                Name = "worker" + Guid.NewGuid(),
            };
            thread.Start();
        }
        private void Run()
        {
            foreach (var task in _queue.GetConsumingEnumerable(_cancellation.Token))
            {
                Count++;
                task();
            }
        }
        public void Schedule(Action task)
        {
            _queue.Add(task);
        }
    }
