    DateTime dbTime = model.MyPropertyFromDB;
    TimeSpan minTime = new TimeSpan(0, 0, 0);
    TimeSpan maxTime = new TimeSpan(23, 59, 59);
    if (dbTime.TimeOfDay > minTime && dbTime.TimeOfDay < maxTime)
    {
        //Within time range (UTC)
    }
    if (dbTime.ToLocalTime().TimeOfDay > minTime && dbTime.ToLocalTime().TimeOfDay < maxTime)
    {
        //Within time range (local)
    }
