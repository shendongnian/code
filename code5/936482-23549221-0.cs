    async Task GetDataAndPostProcessAsync(Identifier identifier, CancellationToken token)
    {
      var url = BuildUrl(identifier, input.PeriodInYear, input.Interval);
      var content = await _webRequest.GetDataAsync(url, token);
      // Use 'content' with 'identifier'
    }
    ...
    var tasks = input.Identifiers.Select(identifier =>
        GetDataAndPostProcessAsync(identifier, token)).ToList();
    await Task.WhenAll(tasks);
