    static bool NowWithinShiftTime(string shiftStart, string shiftEnd)
    {
        DateTime startDate;
        DateTime endDate;
        DateTime now = DateTime.Now; 
        TimeSpan startTime = DateTime.Parse(shiftStart).TimeOfDay;
        TimeSpan endTime = DateTime.Parse(shiftEnd).TimeOfDay;
        if (startTime < endTime) // same day
        {
            startDate = DateTime.Today + startTime;
            endDate = DateTime.Today + endTime;
        }
        else // next day
        {
            startDate = DateTime.Today  + startTime;
            endDate = DateTime.Today.AddDays(1) + endTime;
        }
        if (now >= startDate && now <= endDate)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
