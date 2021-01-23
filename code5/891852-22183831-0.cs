    /// <summary>
    /// Waits for the rate and review URL to show up or until the time-out limit expires.
    /// </summary>
    /// <param name="timeoutSecs">The number of seconds to wait before giving up.</param>
    /// <returns>Returns the rate & review URL if it was retrieved, NULL if the request timed-out</returns>
    async private Task<string> WaitForRateAndReviewUrlAsync(int timeoutSecs = 30)
    {
      if (timeoutSecs < 0)
        throw new ArgumentException("The time-out value is negative.");
      var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeoutSecs));
      var completedTask = await Task.WhenAny(timeoutTask, GetMainViewModel.RateAndReviewURL.Task);
      if (completedTask == timeoutTask)
        return null;
      return GetMainViewModel.RateAndReviewURL.Result;
    }
