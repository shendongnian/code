    public static long ConvertDateTimeTo(string date)
    {
      long LongAdj = 1000;
      var mydate = Convert.ToDateTime(date);
      var UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
      return (long)((mydate - UnixEpoch).TotalSeconds * LongAdj);
    }
