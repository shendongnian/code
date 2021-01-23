       public class Timer : IDisposable
       {
            private readonly Stopwatch _stopwatch;
            private readonly Action<TimeSpan> _finishedDelegate;
    
            private Timer(Action<TimeSpan> finishedDelegate)
            {
                if (finishedDelegate == null)
                {
                    finishedDelegate = timeSpan => Debug.Print("Elapsed time: {0}", timeSpan);
                }
                
                _finishedDelegate = finishedDelegate;
                _stopwatch = Stopwatch.StartNew();
            }
    
            public static Timer Start(Action<TimeSpan> finishedDelegate = null)
            {
                return new Timer(finishedDelegate);
            }
    
            public void Dispose()
            {
                _stopwatch.Stop();
                _finishedDelegate.Invoke(_stopwatch.Elapsed);
            }
       }
