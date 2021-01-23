    class TickHandler
    {
       static object StaticSyncObject = new object();
       static bool IsBusy = false;
    
       static void HandleTimerElapsed(object source, ElapsedEventArgs e)
       {
          lock(StaticSyncObject)
          {
              if( IsBusy ) 
                 return;
              else 
                 IsBusy = true;
          }
          try {
    
              // ... do some work here ...  hopefully often faster than interval.
    
          } finally {
             lock(StaticSyncObject)
             {
                IsBusy = false;
             }
          }
       }
    }
