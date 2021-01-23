    public Task Example()
    {
        Foo();
        var syncContext = SyncronizationContext.Current;
        return BarAsync().ContinueWith((continuation) =>
                        {
                            Action postback = () => 
                            {
                                long barResult = continuation.Result;
                                Baz(barResult)
                            }
                            if(syncContext != null)
                                syncContext.Post(postback);
                            else
                                Task.Run(postback);
                        });
    }
    private Task<long> BarAsync()
    {
         return Task.Run(() => 
         {
               long i = 0;
               
               for(long j = 0; j < int.MaxValue; j++)
               {
                   unchecked
                   {
                       i = i + j;
                   }
               }
               return i;
         }
    }
