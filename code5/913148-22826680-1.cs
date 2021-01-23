    public class Birthday
    {
     public int GetLeapYearDaysData()
     {
       // some self-logic..
    
       // now call our static method
       var isLeapYear = DateHelper.IsLeapYear();
    
       // based on this value, you might return 100 or 200.
    
       if (isLeapYear)
       {
        return 100;
       }
       
       return 200;
     }
    }
