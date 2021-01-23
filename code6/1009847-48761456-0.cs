    private bool DatesAreInTheSameWeek(DateTime date1)
        {
            if (date1 == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                CultureInfo myCI = new CultureInfo("en-US");
                var BirtdayWithCurrentYear = new DateTime(DateTime.Today.Year, date1.Month, date1.Day);
                var birthdayWeek = cal.GetWeekOfYear(BirtdayWithCurrentYear, myCI.DateTimeFormat.CalendarWeekRule, myCI.DateTimeFormat.FirstDayOfWeek);
                var todayWeek = cal.GetWeekOfYear(DateTime.Today, myCI.DateTimeFormat.CalendarWeekRule, myCI.DateTimeFormat.FirstDayOfWeek);
                return birthdayWeek == todayWeek;
            }
        }
 
