    public static async Task<DashboardResponse> GetDashboardAsync()
    {
      var resp = new DashboardResponse();
      var monthAtAGlanceTask = GetMonthAtAGlanceAsync();
      var mostRecentOrderTask = GetMostRecentOrderAsync();
      ...
      await Task.WhenAll(monthAtAGlanceTask, mostRecentOrderTask, ...);
      resp.MonthGlance = await monthAtAGlanceTask;
      resp.MostRecentOrder = await mostRecentOrderTask;
      ...
      return resp;
    }
