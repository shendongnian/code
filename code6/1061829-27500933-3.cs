    private int IsWithinResidencyRange(DateTime dateFrom, DateTime dateTo, double consecutiveHours){
        var dates = new List<DateTime>();
        for (var date = dateFrom; date <= dateTo; date = date.AddDays(1))
            dates.Add(date);
        var occurances = 0;
        foreach (var testDate in dates)
        {
            var testFrom = new DateTime(testDate.Year, testDate.Month, testDate.Day, timeFromResidencyRange.TimeOfDay.Hours, timeFromResidencyRange.TimeOfDay.Minutes,0);
            var testTo = new DateTime(testDate.Year, testDate.Month, testDate.Day, timeToResidencyRange.TimeOfDay.Hours, timeToResidencyRange.TimeOfDay.Minutes, 0);
            if (WithinFrame(dateFrom, dateTo, consecutiveHours, testFrom, testTo))
                occurances++;
        }
        return occurances;
            
    }
    private bool WithinFrame(DateTime from, DateTime to, double consecutiveHours, DateTime rangeFrom, DateTime rangeTo)
    {
        if (from.TimeOfDay < rangeFrom.TimeOfDay)
        {
            return ((to - rangeFrom).TotalHours >= consecutiveHours);
        }
        else if (to.TimeOfDay > rangeTo.TimeOfDay)
        {
            return ((rangeTo - from).TotalHours >= consecutiveHours);
        }
        else
        {
            //Is completely within range.
            return ((to - from).TotalHours >= consecutiveHours);
        }
    }
