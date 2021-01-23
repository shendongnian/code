    [Function(Name="dbo.GetWeek", IsComposable=true)]
    public int GetWeekNumber([Parameter(Name="@dt", DbType="datetime")]DateTime date)
    {
      Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
      return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }
