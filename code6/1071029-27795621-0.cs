    public class DateRange
    {
       public DateTime Start { get; private set; }
       public DateTime End { get; private set; }
    
       public DateRange(DateTime startDate, DateTime endDate)
       {
           if (endDate < startDate)
              throw new ArgumentOutOfRangeException("endDate");
    
           Start = startDate;
           End = endDate;
       }
    }
