    public class TaskAuditor<T>
    {
      private Func<Task<T>> _func;
      private Stopwatch _sw = new Stopwatch();
      public TaskAuditor(Func<Task<T>> func)
      {
        _func = func;
      }
      public async Task<T> StartAsync()
      {
        _sw.Start();
        try
        {
          return await _func();
        }
        finally
        {
          _sw.Stop();
        }
      }
      public TimeSpan? Duration()
      {
        TimeSpan? result = null;
        if (!_sw.IsRunning)
        {
           result = _sw.Elapsed;
        }
        return result;
      }
    }
