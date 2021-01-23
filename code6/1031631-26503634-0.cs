     public int NumberTicketsThreeMonthsAgo
     {
         get 
         {
             new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-3)
         }
     }
