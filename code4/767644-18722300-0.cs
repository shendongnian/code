     public static class StringExtensions
     {
          public static int ToInt(this string str)
          {
                int n;
                if(Int32.TryParse(str, out n))
                   return n;
                else
                   return 0;
          }
    }
