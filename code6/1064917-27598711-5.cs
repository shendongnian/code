    public static DateTime? ToDate(this object obj)
    {
       DateTime dt;
       if (DateTime.TryParseExact(obj.ToString(), "dd/MM/yyyy",
                                  CultureInfo.InvariantCulture,
                                  DateTimeStyles.None, out dt))
       {
            return dt;
       }
       return null;
    }
