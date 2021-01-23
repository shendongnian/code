    private async Task<string> LongTask()
    {
       if(isInCache)
       { 
          return cachedValue(); // cache value is a const string you can do return "1" instead.
       }
       // else do the long thing and return my Task<string>
       return await DoSomethingLong();
    }
