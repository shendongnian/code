    public static IEnumerable<DateTime> GetHours(DateTime startTime, DateTime endTime)
    {
        var currentTime = startTime;
        while (currentTime <= endTime)
        {
            yield return currentTime;
            currentTime = currentTime.AddHours(1);
        }
    }
