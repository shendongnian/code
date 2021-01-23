    private Task<string> LongTask()
    {
       if(isInCache)
       { 
          return Task.FromResult(cachedValue()); 
       }
       // else do the long thing and return my Task<string>
       return DoSomethingLong();
    }
