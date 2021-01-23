    long DaySpan(DateTime t1, DateTime t2)
    {
      days = (t2 - t1).TotalDays;
      for(int i = t1.Year; i< t2.Year; i++)
      {
         if(Date.IsLeapYear(i))
         {
           days--;
         }
      }
      if((Convert.ToInt32(t2.Month) != 1 || Convert.ToInt32(t2.Month) != 2)&&Date.IsLeapYear(t2.Year))
      {
         days--;
      }
      if((Convert.ToInt32(t1.Month) != 1 || Convert.ToInt32(t1.Month) != 2)&&Date.IsLeapYear(t1.Year))
      {
         days--;
      }
      return days;
    }
