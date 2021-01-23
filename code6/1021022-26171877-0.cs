    public static class LocalLogger
    {
      private static readonly string name = Guid.NewGuid().ToString("N");
      // Static Log methods should read this.
      public static ILogger CurrentLogger
      {
        public get
        {
          var ret = CallContext.LogicalGetData(name) as ILogger;
          return ret == null ? Logger.GlobalLogger : ret;
        }
        private set
        {
          CallContext.LogicalSetData(name, value);
        }
      }
      // Client code uses this.
      public static IDisposable UseLogger(ILogger logger)
      {
        var oldLogger = CurrentLogger;
        CurrentLogger = logger;
        if (oldLogger == GlobalLogger)
          return NoopDisposable.Instance;
        return new SetWhenDisposed(oldLogger);
      }
      private sealed class NoopDisposable : IDisposable
      {
        public void Dispose() { }
        public static readonly Instance = new NoopDisposable();
      }
      private sealed class SetWhenDisposed : IDisposable
      {
        private readonly ILogger _oldLogger;
        private bool _disposed;
        public SetWhenDisposed(ILogger oldLogger)
        {
          _oldLogger = oldLogger;
        }
        public void Dispose()
        {
          if (_disposed)
            return;
          CurrentLogger = _oldLogger;
          _disposed = true;
        }
      }
    }
