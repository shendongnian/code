    async Task Method() {
      var context = GetSomeContext();
      var result = await TimeConsumingWebServiceCallAsync();
      context.Result = result;
    }
    
    async Task TimeConsumingWebServiceCallAsync() {
        var httpClient = new HttpClient();
        var results = await httpClient.GetStringAsync(url); // or await wcfProxy.YourWCFMethodAsync();         
        // do processing if necessary
        return results;
    }
