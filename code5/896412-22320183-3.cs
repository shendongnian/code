     foreach (ABDate a in AbDateList)
      {
            
        for ( in checkYear = startDate.Year ;checkYear <= EndDate.Year; checkYear ++)
        {
             if ((new DateTime(checkYear ,a.Month,a.Day) >= startDate) && (new DateTime(checkYear ,a.Month,a.Day) <= endDate))
               {
                  // I AM IN BETWEEN
               }
            }
        }
    }
