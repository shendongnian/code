    //TEST 1
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    var hoursLinq = _hourDataSource.Hours
                .Where(hour => hour.Id == profile.Id)
                .Where(hour => hour.DayName.Equals("Maandag"))
                .Where(hour => hour.Day == 1)
                .Select(hour => hour);
    stopWatch.Stop();
    // Get the elapsed time as a TimeSpan value.
    TimeSpan ts1 = stopWatch.Elapsed;
    //TEST 2
    stopWatch = new Stopwatch();
    stopWatch.Start();
    var hoursLinq2 = _hourDataSource.Hours
                .Where(hour => hour.Id == profile.Id)
                .Select(hour => hour);
    if (hoursLinq2.Count() != 0)
    {
        var hoursLinq3 = _hourDataSource.Hours
                .Where(hour => hour.DayName.Equals("Maandag"))
                .Select(hour => hour);
        if (hoursLinq3.Count() != 0)
        {
            var hoursLinq4 = _hourDataSource.Hours
                .Where(hour => hour.Day == 1)
                .Select(hour => hour);
        }
    }
    stopWatch.Stop();
    // Get the elapsed time as a TimeSpan value.
    TimeSpan ts2 = stopWatch.Elapsed;
    //TEST 3
    stopWatch = new Stopwatch();
    stopWatch.Start();
    var hoursLinq5 = _hourDataSource.Hours
                .Where(hour => hour.Id == profile.Id &&
                                hour.DayName.Equals("Maandag") &&
                                hour.Day == 1)
                .Select(hour => hour);
    stopWatch.Stop();
    // Get the elapsed time as a TimeSpan value.
    TimeSpan ts3 = stopWatch.Elapsed;
