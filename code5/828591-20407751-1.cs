    DateTime nextRent;
    DateTime lastRent;
    DateTime today = DateTime.Now;
         
    if (today.DayOfWeek == DayOfWeek.Wednesday)
    {
       nextRent = today.AddDays(7);
       lastRent = today.AddDays(-7);
    }
    else if (today.DayOfWeek == DayOfWeek.Thursday)
    {
       nextRent = today.AddDays(6);
       lastRent = today.AddDays(-8);
    }
    //ect for all days
          
