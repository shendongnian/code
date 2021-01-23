    // <summary>Note: this method is not fully synchronous; it will block the calling thread.</summary>
    public async Task<StuffAnalysis> GetAndAnalyzeStuffAsync(CancellationToken token)
    {
      var stuff = GetStuff(token);
      var analysis = await AnalyzeStuff(stuff, token).ConfigureAwait(false);
      return analysis;
    }
