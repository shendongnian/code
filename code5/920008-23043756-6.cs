    public class AsyncOperatingContext
    {
      struct Continuation
      {
        private readonly SendOrPostCallback d;
        private readonly object state;
        public Continuation(SendOrPostCallback d, object state)
        {
          this.d = d;
          this.state = state;
        }
        public void Run()
        {
          d(state);
        }
      }
      class BlockingSynchronizationContext : SynchronizationContext
      {
        readonly BlockingCollection<Continuation> _workQueue;
        public BlockingSynchronizationContext(BlockingCollection<Continuation> workQueue)
        {
          _workQueue = workQueue;
        }
        public override void Post(SendOrPostCallback d, object state)
        {
          _workQueue.TryAdd(new Continuation(d, state));
        }
      }
      /// <summary>
      /// Gets the recommended max degree of parallelism. (Your main program message loop could use this value.)
      /// </summary>
      public static int MaxDegreeOfParallelism { get { return Environment.ProcessorCount; } }
      #region Helper methods
      /// <summary>
      /// Run an async task. This method will block execution (and use the calling thread as a worker thread) until the async task has completed.
      /// </summary>
      public static T Run<T>(Func<Task<T>> main, int degreeOfParallelism = 1)
      {
        var asyncOperatingContext = new AsyncOperatingContext();
        asyncOperatingContext.DegreeOfParallelism = degreeOfParallelism;
        return asyncOperatingContext.RunMain(main);
      }
      /// <summary>
      /// Run an async task. This method will block execution (and use the calling thread as a worker thread) until the async task has completed.
      /// </summary>
      public static void Run(Func<Task> main, int degreeOfParallelism = 1)
      {
        var asyncOperatingContext = new AsyncOperatingContext();
        asyncOperatingContext.DegreeOfParallelism = degreeOfParallelism;
        asyncOperatingContext.RunMain(main);
      }
      #endregion
      private readonly BlockingCollection<Continuation> _workQueue;
      public int DegreeOfParallelism { get; set; }
      public AsyncOperatingContext()
      {
        _workQueue = new BlockingCollection<Continuation>();
      }
      /// <summary>
      /// Initialize the current thread's SynchronizationContext so that work is scheduled to run through this AsyncOperatingContext.
      /// </summary>
      protected void InitializeSynchronizationContext()
      {
        SynchronizationContext.SetSynchronizationContext(new BlockingSynchronizationContext(_workQueue));
      }
      protected void RunMessageLoop()
      {
        while (!_workQueue.IsCompleted)
        {
          Continuation continuation;
          if (_workQueue.TryTake(out continuation))
          {
            continuation.Run();
          }
        }
      }
      protected T RunMain<T>(Func<Task<T>> main)
      {
        var degreeOfParallelism = DegreeOfParallelism;
        if (!((1 <= degreeOfParallelism) & (degreeOfParallelism <= 5000))) // sanity check
        {
          throw new ArgumentOutOfRangeException("DegreeOfParallelism must be between 1 and 5000.", "DegreeOfParallelism");
        }
        var currentSynchronizationContext = SynchronizationContext.Current;
        InitializeSynchronizationContext(); // must set SynchronizationContext before main() task is scheduled
        var mainTask = main(); // schedule "main" task
        mainTask.ContinueWith(task => _workQueue.CompleteAdding());
        // for single threading we don't need worker threads so we don't use any
        // otherwise (for increased parallelism) we simply launch X worker threads
        if (degreeOfParallelism > 1)
        {
          for (int i = 1; i < degreeOfParallelism; i++)
          {
            ThreadPool.QueueUserWorkItem(_ => {
              // do we really need to restore the SynchronizationContext here as well?
              InitializeSynchronizationContext();
              RunMessageLoop();
            });
          }
        }
        RunMessageLoop();
        SynchronizationContext.SetSynchronizationContext(currentSynchronizationContext); // restore
        return mainTask.Result;
      }
      protected void RunMain(Func<Task> main)
      {
        // The return value doesn't matter here
        RunMain(async () => { await main(); return 0; });
      }
    }
