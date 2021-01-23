     private DateTime GetNextEscalationDate(DateTime lastEscalationDate, int elapsedDays)
     {
     int count = 0;
     int j = elapsedDays;
            
     for (int i = 1; i <= j; i++)
     {
         if ((lastEscalationDate.AddDays(i).DayOfWeek == DayOfWeek.Saturday) ||
         (lastEscalationDate.AddDays(i).DayOfWeek == DayOfWeek.Saturday))
         {
             count += 2;
             j += 2;
         }
     }
     DateTime weekendDiscountedDate = lastEscalationDate.AddDays(elapsedDays + count);
     return weekendDiscountedDate;
}
