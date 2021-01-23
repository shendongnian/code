    public class FileUpdateController<TData>
    {
        private readonly object _gate = new object();
        private readonly Dictionary<string, TaskCompletionSource<string>> _pendingTasks;
        private readonly Dictionary<string, TaskCompletionSource<string>> _runningTasks;
        private readonly Dictionary<string, TData> _dataCache;
        private readonly IScheduler _scheduler;
        public FileUpdateController(IScheduler scheduler)
        {
            if(scheduler == null) scheduler = ThreadPoolScheduler.Instance;
            _scheduler = scheduler;
            _pendingTasks = new Dictionary<string, TaskCompletionSource<string>>();
            _runningTasks = new Dictionary<string, TaskCompletionSource<string>>();
            _dataCache = new Dictionary<string, TData>();
        }
        public Task<string> QueueFileUpdate(string filename, TData data)
        {
            lock (_gate)
            {
                Task<string> task;
                if (_pendingTasks.ContainsKey(filename))
                {
                    task = _pendingTasks[filename].Task;
                }
                else
                {
                    var tcs = new TaskCompletionSource<string>(filename);
                    _pendingTasks.Add(filename, tcs);
                    task = tcs.Task;
                }
                if (!_runningTasks.ContainsKey(filename))
                {
                    _runningTasks.Add(filename, _pendingTasks[filename]);
                    _pendingTasks.Remove(filename);
                    _scheduler.Schedule(() => UpdateFile(filename, data));
                }
                else
                {
                    _dataCache[filename] = data;
                }
                return task;
            }            
        }
        private async void UpdateFile(string filename, TData data)
        {
            Console.WriteLine("Updating file " + filename + " with data " + data);
            await Observable.Timer(TimeSpan.FromSeconds(5), _scheduler).ToTask();
            lock (_gate)
            {
                var tcs = _runningTasks[filename];
                _runningTasks.Remove(filename);
                if (_pendingTasks.ContainsKey(filename))
                {
                    _runningTasks.Add(filename, _pendingTasks[filename]);
                    _pendingTasks.Remove(filename);
                    var cachedData = _dataCache[filename];
                    _dataCache.Remove(filename);
                    _scheduler.Schedule(() => UpdateFile(filename, cachedData));
                }
                tcs.SetResult(Unit.Default);
                Console.WriteLine("Updated file " + filename + " with data " + data);
            }
        }
    }
