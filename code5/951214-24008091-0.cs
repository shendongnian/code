     Public DateTime GetNextWeekday(DayOfWeek day)
     {
         DateTime result = DateTime.Now.AddDays(1);
         while( result.DayOfWeek != day )
              result = result.AddDays(1);
         return result;
     }
     DateTime deltaMonday=GetNextWeekday(1)
     DateTime deltaWednesday=GetNextWeekday(3)
     DateTime deltaSaturday=GetNextWeekday(6)
     
