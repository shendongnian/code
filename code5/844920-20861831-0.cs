    private bool CheckTransactionDates(string line)
    { 
       // in the actual code this is dynamically set based on other variables
       int month = DateTime.Now.Month;
       int daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
    
       Regex pattern = new Regex(string.Format(@"{0:00}-(?<DAY>[0123][0-9])", month));
       int day = 0;
        
       foreach (Match match in pattern.Matches(line))
       {
          if (int.TryParse(match.Groups["DAY"].Value, out day))
          {
             if (day <= daysInMonth)
             {
                return true;
             }
          }
       }
    
       return false;
    }
