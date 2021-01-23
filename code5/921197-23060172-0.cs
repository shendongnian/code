      public static int GetWeekNumber(DateTime dt)
      {
              CultureInfo curr= CultureInfo.CurrentCulture;
              int week = curr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
              return week;
      }
