    public class Holiday
    {
         public DateTime Start { get; set; }
         public DateTime End { get; set; }
         public List<Holiday> GetHolidays()
         {
              return new List<Holiday>() { new Holiday() { 
                    Start = new DateTime(2013, 9, 19), 
                    End = new DateTime(2013, 9, 20)
              };
         }
         public bool IsHoliday(DateTime date)
         {
              return GetHolidays().Where(c => c.Start <= date && c.End >= date).Count() > 0;
         }
    }
