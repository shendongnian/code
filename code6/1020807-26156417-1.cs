    public partial class Stamping
    {
        ...
        public int WeekNo
        {
            get
            {
                var currentCulture = CultureInfo.CurrentCulture;
                int weekNo = currentCulture.Calendar.GetWeekOfYear(
                             this.Timestamp,
                             CalendarWeekRule.FirstFourDayWeek,
                             DayOfWeek.Monday);
                return weekNo;
            }
        }
    }
