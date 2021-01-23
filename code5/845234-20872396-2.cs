    public enum HolidayType
    {
        None,
        SatOrSun,
        PublicHoilday,
        RestrictedHoliday
    }
    public class Day
    {
        public int? NumericDay { get; set; }
        public HolidayType HolidayType { get; set; }
    }
    public class DashboardDateDetails
    {
        public string MonthName { get; set; }
        public List<Day> Days { get; set; }
    }
