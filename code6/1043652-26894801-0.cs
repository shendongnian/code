    public Task<string> SomeMethodAsync(string url)
    {
       // do some URL validation
       if (!valid)
       {
         throw new Exception("some error");
       }
       // do async stuff now
       return SomeMethodImplAsync(url);
    }
    private async Task<string> SomeMethodImplAsync(string url)
    {
      return await GetFromUrl(url)
    }
