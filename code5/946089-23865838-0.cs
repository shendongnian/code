    public class MyClass : MyBaseClass, IDisposable
    {
       private Timer _timer;
       private volatile bool _isStopped = true;
    
       public MyClass()
       {
           _timer = new Timer();
           _timer.Interval = 1000;
           _timer.Elapsed = OnTimerElapsed;
       }
    
       public void Stop()
       {
           _isStopped = true;
           _timer.Stop();
       }
    
       public void Dispose()
       {
          if (_timer != null)
          {
              Stop();
              _timer = null;
          }
       }
    
       protected override void OnSomethingHappens()
       {
           if (_timer.Enabled)
           {
              // Restart or do nothing if timer is already running?
           }
           else
           {
              _isStopped = false;
              _timer.Start();              
           }
       }
    
       private void OnTimerElapsed(object sender, EventArgs a)
       {
          if (_isStopped)
          {
              // If the Stop method was called after the Elapsed event was raised, don't start a long running operation
              return;
          }
       }
    }
