    public class ViewModel
    {
        public ViewModel()
        {
            DashboardDates = new List<DashboardDateDetails>();
            GenerateCalendar();
        }
        //This will be binded to ItemsSource
        public List<DashboardDateDetails> DashboardDates { get; set; }
        //Suppose these are Restricted Holidays
        List<DateTime> RestrictedHolidays = new List<DateTime>{
            new DateTime(2014,2,1),
            new DateTime(2014,3,5),
            new DateTime(2014,4,15),
            new DateTime(2014,6,2),
            new DateTime(2014,8,15),
            new DateTime(2014,11,25),
            new DateTime(2014,12,24)
        };
        //Suppose these are Public Holidays
        List<DateTime> PublicHolidays = new List<DateTime>{
            new DateTime(2014,2,1),
            new DateTime(2014,3,15),
            new DateTime(2014,4,19),
            new DateTime(2014,6,20),
            new DateTime(2014,8,11),
            new DateTime(2014,11,12),
            new DateTime(2014,12,25)
        };
        void GenerateCalendar()
        {
            //Lop for 12 months
            for (int month = 1; month <= 12; month++)
            {
                //firstdate for month.This will help to get the first day of month
                var firstdate = new DateTime(2014, month, 1);
                //Get the first date index
                int firstDateIndex = (int)firstdate.DayOfWeek;
                //In DayOfWeek enum first day is Sunday but we want Monday so decrement the index
                firstDateIndex--;
                //Restricted holidays for this month
                var restrictedHolidays = RestrictedHolidays.Where(s => s.Month == month);
                //Public holidays for this month
                var publicHolidays = PublicHolidays.Where(s => s.Month == month);
                //Instance of DashboardDateDetails
                DashboardDateDetails details = new DashboardDateDetails
                {
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                    Days = new Day[40].ToList()  //Create an array of capacity 40
                };
                for (int j = 1; j <= DateTime.DaysInMonth(2014, month); j++)
                {
                    int index = 0;
                    if (firstDateIndex < 0)
                        index = j - 1;
                    else
                        index = j + firstDateIndex - 1;
                    var day = new Day { NumericDay = j };
                    //is sat or sun
                    if (((index % 7) == 6) || ((index % 7) == 5))
                        day.HolidayType = HolidayType.SatOrSun;
                    //is restricted holiday
                    if (restrictedHolidays.Any(s => s.Day == index))
                        day.HolidayType = HolidayType.RestrictedHoliday;
                    //is public holiday
                    if (publicHolidays.Any(s => s.Day == index))
                        day.HolidayType = HolidayType.PublicHoilday;
                    details.Days[index] = day;
                }
                DashboardDates.Add(details);
            }
        }
    
    }
