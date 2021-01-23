    public int NestedTask(IEnumerable<MatchTier> tierNodes)
    {
      var tasks = tierNodes.Select(node => Task<int>.Factory.StartNew(() =>
                {
                    // Task logic goes here
                    return 1; // temp placeholder
                })).ToList(); // Enumerate to start tasks, not doing this would case WaitAll to start them one at a time (i believe)
      if (!Task.WaitAll(tasks, timeOutInMilliseconds))
        // Handle timeout...
      return tasks.First().Result; // Is this what you want?
    }
