    public async Task<ActionResult> GetChartContents(int[] ids, bool isDraft = false)
    {
      var charts = ...;
      var chartTasks = Enumerable.Range(0, ids.Length)
          .Select(i => _dataService.GetDataForChartAsync(charts[i], isDraft, _user.Id))
          .ToArray();
      var results = await Task.WhenAll(chartTasks);
      ...
      return View(results);
    }
