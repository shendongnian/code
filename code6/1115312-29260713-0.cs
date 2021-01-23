    public async Task DownloadLoopAsync() 
    {
        while ( this.isLooping )
        {
          var tasks = this
            .Identifiers
            .Select(id => RequestNewDataAsync(this.generateRequestString(id));
          await Task.WhenAll(tasks);
        }
    }
