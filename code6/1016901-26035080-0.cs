    private int GetWeekOfYear(DateTime d)
            {
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                return cal.GetWeekOfYear(new DateTime(d.Year, d.Month, 1), System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday);
            }
