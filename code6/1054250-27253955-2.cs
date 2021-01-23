     //Common methods for validating method parameters
     public static class Ensure
     {
          public static void NotNull(object o, string paramName)
          {
              if (null == o)
                  throw new ArgumentNullException(paramName);
          }
          public static void NotZero(Point p, string paramName){ /*logic*/ }
    
          public static void GreaterThanZero(int i, string paramName)
          {
              if (i <= 0)
                   throw new ArgumentException("Must be greater than zero", paramName);
                
          }
     }
