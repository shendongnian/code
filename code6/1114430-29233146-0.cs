    public Dictionary<PIPoint, AFValues>[] DoTask(PIServer server, AFTimeRange timeRange)
    {
      var timeRanges = DivideTheTimeRange(timeRange);
      var result = timeRanges.AsParallel().AsOrdered().
          Select(range => CalculationClass.AverageValueOfTagPerDay(server, range)).
          ToArray();
      return result;
    }
