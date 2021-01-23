     void UsingAndLog<T>(Func<T> creator, Action<T> action) where T:IDisposabe
     {  
          T item = creator();
          try 
          {
             action(item);
          }
          finally
          { 
              try { item.Dispose();}
              catch(Exception ex)
              {
                 // Log/pick which one to throw.
              } 
          }      
     }
     UsingAndLog(() => new FileStream(...), item => 
     {
         //code that you'd write inside using 
         item.Write(...);
     });
     
