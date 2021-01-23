    public static class StringExtensions
    {
       public static decimal? ToNullableDecimal(this string s)
       {
          decimal value;
          if (!Decimal.TryParse(s, out value)
             return null;
          return value;
       }
    }
