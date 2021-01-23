    TimeSpan ts = newTime - startingTime;
    string.Format("{0:00}:{1:00}:{2:00}",
                                 (int)ts.TotalHours,
                                      ts.Minutes,
                                      ts.Seconds);
