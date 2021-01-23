    static bool NowWithinShiftTime(string shiftStart, string shiftEnd)
    {
       DateTime now = DateTime.Now;
       DateTime startDate = DateTime.Parse(shiftStart);
       DateTime endDate = DateTime.Parse(shiftEnd);
       if (endDate < startDate)
       {
            endDate = endDate.AddDays(1);
       }
       return now >= startDate && now <= endDate;
    }
