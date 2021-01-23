    public sealed class AsyncLock
    {
        #region Data Members
        private readonly Task<IDisposable> _releaserTask;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly DisposableScope _releaser;
        #endregion
        #region Constructors
        public AsyncLock()
        {
            _releaser = new DisposableScope(() => _semaphore.Release());
            _releaserTask = Task.FromResult(_releaser as IDisposable);
        }
        #endregion
        #region Methods
        public IDisposable Lock()
        {
            _semaphore.Wait();
            return _releaser;
        }
        public Task<IDisposable> LockAsync()
        {
            var waitTask = _semaphore.WaitAsync();
            return waitTask.IsCompleted
                ? _releaserTask
                : waitTask.ContinueWith(
                    (_, releaser) => (IDisposable)releaser,
                    _releaser,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }
        #endregion
    }
