    public class ExactDayHoliday : IHoliday
    {
      public int Day {get; set;}
      public int Month {get; set;}
    
      public bool isHoliday(DateTime date)
      {
        return date.Month == month && date.Day == day;
      }
    }
