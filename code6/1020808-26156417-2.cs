    public class DateConverter
    {
        public static DateTime FirstDateOfWeek(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            int weekNo = currentCulture.Calendar.GetWeekOfYear(
                         date,
                         CalendarWeekRule.FirstFourDayWeek,
                         DayOfWeek.Monday);
            var daysOffset = DayOfWeek.Thursday - date.DayOfWeek;
            var firstThursday = date.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    
            if (firstWeek <= 1)
            {
                weekNo -= 1;
            }
    
            var result = firstThursday.AddDays(weekNo * 7);
    
            return result;
        }
    }
