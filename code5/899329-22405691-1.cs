    public class TimeUnit
    {
      private readonly string _unit;
    
      private TimeUnit(string unit)
      {
        _unit = unit;
      }
    
      public static TimeUnit Hour = new TimeUnit("hour");
      public static TimeUnit Day = new TimeUnit("day");
      public string ToString()
      {
        return _unit;
      }
    }
