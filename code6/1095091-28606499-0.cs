    void Main()
    {
    	var allDates = new List<Tuple<DateTime,DateTime>>();
    	var startDate = DateTime.Now;
    	var endDate = startDate.AddDays(20);
    	
    	for (var date = startDate; date <= endDate; date = date.AddDays(1))
    	    allDates.Add(Tuple.Create(date.StartOfDay(startDate),date.EndOfDay()));
    		
    	allDates.Dump();
    	
    	
    } 
    static class DateExt
    {
       // Define other methods and classes here
       public static DateTime StartOfDay(this DateTime date, DateTime referenceDate)
       {
    	   return date.Subtract(referenceDate).Ticks == 0
    		   ? referenceDate
    		   : new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
       }
       public static DateTime EndOfDay(this DateTime date)
       {
           return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
       }
    }
