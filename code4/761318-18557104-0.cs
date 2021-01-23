    public static class StringExtensions
    {
       public static DateTime ToDate(this string str)
       {
          IFormatProvider provider = System.Globalization.CultureInfo.InvariantCulture;
          string format = "MM-ddTHH:mm";
          return DateTime.ParseExact(str, format, provider);
       }
    }
