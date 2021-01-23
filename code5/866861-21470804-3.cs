    // <summary>Note: this method is not fully synchronous; it will block the calling thread.</summary>
    public Task<StuffAnalysis> GetAndAnalyzeStuffAsync(CancellationToken token)
    {
      var stuff = GetStuff(token);
      return AnalyzeStuff(stuff, token);
    }
