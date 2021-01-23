    public static int PreviousQuarter(DateTime? date = null)
    {
     int month;
       if (date.HasValue){
         month =  date.Value.Month;
       } else { 
         month = DateTime.Now.AddMonths(-3).Month)
       }
     float quarter =   month / 4;
     return (int)Math.Ceiling(quarter +0.1);
    }
    
