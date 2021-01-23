    public static DateTime ConvertToDateTime(int intDateTime)
    {
       DateTime dt = new DateTime();
       if (intDateTime.ToString().Length == 4)
       {
          dt = DateTime.ParseExact(intDateTime.ToString(), "yyyy", CultureInfo.InvariantCulture);
       }
       if (intDateTime.ToString().Length == 6)
       {
           dt = DateTime.ParseExact(intDateTime.ToString(), "yyyyMM", CultureInfo.InvariantCulture);
       }
       if (intDateTime.ToString().Length == 8)
       {
           dt = DateTime.ParseExact(intDateTime.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
       }
       return dt;
    }
