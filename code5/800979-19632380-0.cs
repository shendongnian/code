    DateTime date1 = new DateTime(2010, 1, 18);
    DateTime date2 = new DateTime(2013, 2, 22);
    
    int oldMonth = date2.Month;
    while (oldMonth == date2.Month)
    {
         date1 = date1.AddDays(-1);
         date2 = date2.AddDays(-1);
    }       
        
    int years = 0, months = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0;
        
    // getting number of years
    while (date2.CompareTo(date1) >= 0)
    {
         years++;
         date2 = date2.AddYears(-1);
    }
    date2 = date2.AddYears(1);
    years--;
        
        
    // getting number of months and days
    oldMonth = date2.Month;
    while (date2.CompareTo(date1) >= 0)
    {
         days++;
         date2 = date2.AddDays(-1);
         if ((date2.CompareTo(date1) >= 0) && (oldMonth != date2.Month))
         {
              months++;
              days = 0;
              oldMonth = date2.Month;
         }
    }
    date2 = date2.AddDays(1);
    days--;
        
    TimeSpan difference = date2.Subtract(date1);
    
    Console.WriteLine("Difference: " +
                        years.ToString() + " year(s)" +
                        ", " + months.ToString() + " month(s)" +
                        ", " + days.ToString() + " day(s)");
  
