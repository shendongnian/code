    public class BackgroundWordFilter : IDisposable
    {
        private readonly List<string> _items;
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
        private readonly Thread _workerThread;
        private readonly int _maxItemsToMatch;
        private readonly Action<List<string>> _callback;
        private volatile bool _shouldRun = true;
        private volatile string _currentEntry = null;
        public BackgroundWordFilter(
            List<string> items, 
            int maxItemsToMatch, 
            Action<List<string>> callback)
        {
            _items = items;
            _callback = callback;
            _maxItemsToMatch = maxItemsToMatch;
            _workerThread = new Thread(WorkerLoop)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            _workerThread.Start();
        }
        public void SetCurrentEntry(string currentEntry)
        {
            _currentEntry = currentEntry;
            _signal.Set();
        }
        private void WorkerLoop()
        {
            while (_shouldRun)
            {
                _signal.WaitOne();
                var entry = _currentEntry;
                if (string.IsNullOrEmpty(entry))
                {
                    _callback(new List<string>());
                    continue;
                }
                var results = new List<string>();
                foreach (var i in _items)
                {
                    // if matched, add to the list of results
                    if (i.Contains(entry))
                        results.Add(i);
                    // check if the current entry was updated in the meantime,
                    // or we found enough items
                    if (entry != _currentEntry || results.Count >= _maxItemsToMatch)
                        break;
                }
                if (entry == _currentEntry)
                    _callback(results);
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool managed)
        {
            if (!managed)
                return;
            if (_workerThread.IsAlive)
            {
                _shouldRun = false;
                _currentEntry = null;
                _signal.Set();
                _workerThread.Join();
            }
            _signal.Dispose();
        }
    }
