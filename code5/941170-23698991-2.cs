    public async Task<string> GetSomeValueAsync()
    {
      //directly return the value of the Method 'DoSomeHeavyWork'...
      var t = DoSomeHeavyWorkAsync();
      return await t;
    }
    public async Task<string> DoSomeHeavyWorkAsync()
    {
      // Call asynchronous WCF client.
      await ...;
      return "Hello World!";
    }
