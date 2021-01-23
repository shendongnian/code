    TimeSpan noon = new TimeSpan(12, 0, 0);
    TimeSpan sixPm = new TimeSpan(18, 0, 0);
    TimeSpan time = dateTime.TimeOfDay;
    if (time < noon)
    {
        ...
    }
    else if (time < sixPm)
    {
        ...
    }
    else
    {
        ...
    }
