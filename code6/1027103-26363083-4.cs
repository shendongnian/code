      public enum TimePeriod {
        None = 0,
        Day = 1,
        // Just week, no "two weeks, three weeks etc."  
        Week = 2,
        Month = 3
      }
    
      public static class Occurrencies {
        // May be you want to convert it to method extension: "this DateTime from" 
        public static IEnumerable<DateTime> FindInterval(DateTime from, TimePeriod period, int count) {
          while (true) {
            switch (period) {
              case TimePeriod.Day:
                from = from.AddDays(count); 
    
                break;  
              case TimePeriod.Week:
                from = from.AddDays(7 * count);    
    
                break;
              case TimePeriod.Month:
                from = from.AddMonths(count);    
                
                break;  
            } 
    
            yield return from;
          }
        }
      }
    
