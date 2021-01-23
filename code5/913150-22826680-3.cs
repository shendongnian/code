    public interface IDateHelper
    {
     bool IsLeapYear();
    }
    
    public class DateHelper : IDateHelper
    {
     public bool IsLeapYear()
     {
      var currentDate = DateTime.UtcNow;
      // check if currentDate's year is a leap year using some unicorn logic
      return true; // or false
     }
    }
