    public async Task<StuffAnalysis> AnalyzeStuffAsync(Stuff stuff, CancellationToken token) 
    {
      var allTasks = new List<Task>();
      using (var stuffAnalyzer = new StuffAnalyzer())
      {
        foreach (var thing in stuff) 
        {
          allTasks.Add(stuffAnalyzer.AnalyzeThingAsync(thing));
        }
        await Task.WhenAll(allTasks).ConfigureAwait(false);
      }
      return stuffAnalyzer.Result;
    }
