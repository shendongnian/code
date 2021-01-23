    public class AsyncBlockingCollection<T>
    { // Missing features: cancellation, boundedCapacity, TakeAsync
        private Queue<T> _queue = new Queue<T>();
        private SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        private int _consumersCount = 0;
        private bool _isAddingCompleted;
        public void Add(T item)
        {
            lock (_queue)
            {
                if (_isAddingCompleted) throw new InvalidOperationException();
                _queue.Enqueue(item);
            }
            _semaphore.Release();
        }
        public void CompleteAdding()
        {
            lock (_queue)
            {
                if (_isAddingCompleted) return;
                _isAddingCompleted = true;
                _semaphore.Release(_consumersCount);
            }
        }
        public IAsyncEnumerable<T> GetConsumingEnumerable()
        {
            lock (_queue) _consumersCount++;
            return new AsyncEnumerable<T>(async yield =>
            {
                while (true)
                {
                    lock (_queue)
                    {
                        if (_queue.Count == 0 && _isAddingCompleted) break;
                    }
                    await _semaphore.WaitAsync();
                    bool hasItem;
                    T item = default;
                    lock (_queue)
                    {
                        hasItem = _queue.Count > 0;
                        if (hasItem) item = _queue.Dequeue();
                    }
                    if (hasItem) await yield.ReturnAsync(item);
                }
            });
        }
    }
