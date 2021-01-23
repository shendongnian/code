    private static long ticks;
    public static DateTime Now
    {
      get
      {
         ticks = UnsafeMethods.GetSystemTimeAsFileTime()
         return new DateTime(ticks); 
      }
    }
