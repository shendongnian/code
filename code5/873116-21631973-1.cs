    using System.Threading;
    using System.Threading.Tasks;
    sealed class Player : IPlayer
    {
      CancellationTokenSource cts;
      long remainingSeconds = 60;
    
      public int RemainingSeconds
      {
        get { return (int)Interlocked.Read(ref remainingSeconds); }
      }
    
      protected async void StartTimer()
      {
        StopTimer();
    
        cts = new CancellationTokenSource();
        
        while(cts != null && !cts.IsCancellationRequested)
        {
          await Task.Delay(1000, cts.Token);
    
          if(cts != null && !cts.IsCancellationRequested)
            Tick();
         }
      }
    
      protected void StopTimer()
      {
        if(cts != null)
          cts.Cancel();
      }
      protected void ResetTimer(int seconds)
      {
         Interlocked.Exchange(ref remainingSeconds, seconds);
      }
    
      protected virtual void Tick()
      {
        Interlocked.Decrement(ref remainingSeconds);
      }
    
    }
