    private IDisposable timerSubscription;
    
    public void StartTimer()
    {
      timerSubscription = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1), Scheduler.TaskPool)
                                    .ObserveOnDispatcher()
                                    .Subscribe(o =>
                                      {
                                        Console.WriteLine("Hooray I'm ticking on TaskPool for {0} times!", o);
                                      }
    }
    
    /// and you can stop timer like this
    public void StopTimer()
    {
          using (timerSubscription)
          {
    
          }
    }
