    public class PerformanceCounterStrategy : ITransientErrorDetectionStrategy
    {
      public bool IsTransient(Exception ex)
      {
        return ex.GetType() == typeof (InvalidOperationException);
      }
    }
