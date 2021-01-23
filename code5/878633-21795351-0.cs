    public List<DateTime> GetListOfDays(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
    {
        var list = new List<DateTime>(); 
        var daysDifference = endDate.Subtract(startDate).TotalDays;
        for (int i = 0; i < daysDifference; i++)
        {
            var date = startDate.AddDays(i); 
            if (date.DayOfWeek == dayOfWeek)
            {
                list.Add(date); 
            }
        }
        return list; 
    }
