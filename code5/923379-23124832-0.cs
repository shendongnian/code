    public static void FirstAndLastDayOfMonth(DateTime date, out DateTime first, out DateTime last) {
      first = new DateTime(date.Year, date.Month, 1);
      DateTime nextFirst;
      if (first.Month == 12) nextFirst = new DateTime(first.Year + 1, 1, 1);
      else nextFirst = new DateTime(first.Year, first.Month + 1, 1);
      last = nextFirst.AddDays(-1);
    }
