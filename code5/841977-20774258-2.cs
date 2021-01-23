    private SemaphoreSlim _initializationSemaphore = new SemaphoreSlim(1);
    private bool _isInitialized = false;    
    private static int _waitingThreads = 0;    
    public void Initialize()
    {
      try
      {
          Interlocked.Increment(ref _waitingThreads);
          await _initializationSemaphore.WaitAsync();
      }
      finally
      {
          Interlocked.Decrement(ref _waitingThreads);
      }
      if (_isInitialized)
      {
         _logger.Warn("SDK is already initialized");
      }
      //Do some logic only once and only ..
      _isInitialized=true;
      _initializationSemaphore.Release();
    }
