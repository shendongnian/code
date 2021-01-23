    // J. van Langen
    public abstract class QueueHandler<T> : IDisposable
    {
        // some events to trigger.
        ManualResetEvent _terminating = new ManualResetEvent(false);
        ManualResetEvent _terminated = new ManualResetEvent(false);
        AutoResetEvent _needProcessing = new AutoResetEvent(false);
        // my 'queue'
        private List<T> _queue = new List<T>();
        public void QueueHandler()
        {
            new Thread(new ThreadStart(() =>
            {
                // what handles it should wait on.
                WaitHandle[] handles = new WaitHandle[] { _terminating, _needProcessing };
                // while not terminating, loop (0 timeout)
                while (!_terminating.WaitOne(0))
                {
                    // wait on the _terminating and the _needprocessing handle.
                    WaitHandle.WaitAny(handles);
                    // my temporay array to store the current items.
                    T[] itemsCopy;
                    // lock the queue
                    lock (_queue)
                    {
                        // create a 'copy'
                        itemsCopy = _queue.ToArray();
                        // clear the queue.
                        _queue.Clear();
                    }
                    if (itemsCopy.Length > 0)
                        HandleItems(itemsCopy);
                }
                // the thread is done.
                _terminated.Set();
            })).Start();
        }
        public abstract void HandleItems(T[] items);
        public void Enqueue(T item)
        {
            // lock the queue to add the item.
            lock (_queue)
                _queue.Add(item);
            _needProcessing.Set();
        }
        // batch
        public void Enqueue(IEnumerable<T> items)
        {
            // lock the queue to add multiple items.
            lock (_queue)
                _queue.AddRange(items);
            _needProcessing.Set();
        }
        public void Dispose()
        {
            // let the thread know it should stop.
            _terminating.Set();
            // wait until the thread is stopped.
            _terminated.WaitOne();
        }
    }
