    public async Task Example()
    {
        Foo();
        long barResult = await BarAsync();
        Baz(barResult);
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
