    class TickHandler
    {
       static object StaticSyncObject = new object();
       static bool IsBusy = false;
       private TickHandlerObject myHandler;
    
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
              myHandler.TickerUpdated();
                               // without any IsBusy checks
                               // without thread safety (1 thread at a time calls)
                               // Note: If you're trying to split up threads below
                               //       this, that's up to you.  Or diff question.
                               //       ie: file/URL read vs memory/GUI update
    
          } finally {
             lock(StaticSyncObject)
             {
                IsBusy = false;
             }
          }
       }
    }
