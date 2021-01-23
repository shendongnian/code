    foreach (ABDate a in AbDateList)
    {
    
     if ((new DateTime(a.Year??startDate.Year,a.Month,a.Day) >= startDate) && (new DateTime(a.Year??endDate.Year,a.Month,a.Day) <= endDate))
       {
          // I AM IN BETWEEN
       }
    }
