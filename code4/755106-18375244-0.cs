    public static IEnumerable<DateTime> GetWeekDays(DateTime date, DayOfWeek start) {
      date = date.Date;
    
      int diff = date.DayOfWeek - start;
    
      if (diff < 0)
        diff += 7;
    
      for (int i = 0; i < 7; ++i)
        yield return date.AddDays(i - diff);
    }
    
    public static IEnumerable<DateTime> GetWeekDays(DateTime date) {
      return GetWeekDays(date, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
    }
    
    ...
    
    List<DateTime> oneWeek = GetWeekDays(DateTime.Now).ToList();
    DateTime[] anotherWeek = GetWeekDays(new DateTime(2012, 5, 7)).ToArray();
