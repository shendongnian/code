    var activityList = activities.ToList();
    activityList.ForEach(a =>
    {
        TimeSpan timeSpent = new TimeSpan(a.TimeSpent);
        a.Days = timeSpent.Days;
        a.Hours = timeSpent.Hours;
        a.Minutes = timeSpent.Minutes;
    });
    return activityList;
