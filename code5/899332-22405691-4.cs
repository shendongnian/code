    public class TimeUnit
    {
      private readonly string _unit;
    
      private TimeUnit(string unit)
      {
        _unit = unit;
      }
    
      public static readonly TimeUnit Hour = new TimeUnit("hour");
      public static readonly TimeUnit Day = new TimeUnit("day");
      public string ToString()
      {
        return _unit;
      }
    }
