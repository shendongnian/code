    using (var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2)))
    {
      List<Task> sendTasks = new List<Task>();
      foreach (var listItem in QueryValues)
      {
        sendTasks.Add(SendEmailAsync(_from, _fromName, cts.Token);
      }
      // wait for all responses to be received
      await Task.WhenAll(sendTasks.ToArray()).ConfigureAwait(false);
    }
