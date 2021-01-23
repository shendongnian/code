    private static async Task<string> ProcessAsync(TaskAuditor<string> auditor)
    {
      try
      {
        return await auditor.StartAsync();
      }
      finally
      {
        Console.WriteLine(auditor.Duration().ToString());
      }
    }
    private static async Task MainAsync()
    {
      var tas = new List<TaskAuditor<string>>();
      tas.Add(new TaskAuditor<string>(() => GetName(string.Empty, 1)));
      tas.Add(new TaskAuditor<string>(() => GetName(string.Empty, 2)));
      var running = tas.Select(ta => ProcessAsync(ta));
      var results = await Task.WhenAll(running);
      foreach (var result in results)
      {
        Console.WriteLine(result);
      }
    }
