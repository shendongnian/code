    DateTime startDate = new DateTime(2014, 09, 01);
    DateTime endDate = new DateTime(2015, 02, 02);
    DateTime loopDate = startDate;
    var totalMonths = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
    if (startDate.Day != 1)
    {
        loopDate = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1);
    }
    
    List<DateTime> firstDayOfMonth = Enumerable.Range(0, totalMonths)
        .Select(i => loopDate.AddMonths(i))
        .ToList();
    
    firstDayOfMonth.Add(new DateTime(endDate.Year,endDate.Month, 1));
