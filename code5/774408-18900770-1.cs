    public class Holiday
    {
         public List<DateTime> GetHolidays()
         {
              return new List<DateTime>() { 
                   new DateTime(2013, 9, 19)
              };
         }
         public bool IsHoliday(DateTime date)
         {
              return GetHolidays().Where(c => c.Date == date.Date).Count() > 0;
         }
    }
