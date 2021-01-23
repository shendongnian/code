    public class InMemoryQueue : ICloudQueue
    {
        private IQueue<object> _queue;
        private readonly ServiceBusQueueSettings _settings;
        public InMemoryQueue(IQueue<object> queue, ServiceBusQueueSettings settings = null)
        {
            _queue = queue;
            _settings = settings;
            if (_settings == null) _settings = new ServiceBusQueueSettings();
        }
        public async Task<IEnumerable<T>> ReceieveAsync<T>(int batchCount)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < batchCount; i++)
            {
                _queue.Dequeue();
            }
            return result;
        }
        public async Task AddToAsync<T>(IEnumerable<T> items)
        {
            items.ToList().ForEach(x => _queue.Enqueue(x));
        }
    }
