    /// <summary>
    /// Customized class for the Date Range Container...
    /// </summary>
    [DataContract]
    public class WeekRange
    {
        [DataMember]
        public string Range { get; set; }
        [DataMember]
        public string StartDate { get; set; }
        [DataMember]
        public string EndDate { get; set; }
        [DataMember]
        public int Week { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Year { get; set; }
    }
           
             /// <summary>
            /// Get the Week Range for the Given Date Range.....
            /// </summary>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <returns></returns>
            public static List<WeekRange> WeekDays(DateTime startDate, DateTime endDate)
            {
                DateTime startDateToCheck = startDate;
                DateTime dateToCheck = startDate;
                DateTime dateRangeBegin = dateToCheck;
                DateTime dateRangeEnd = endDate;
    
                List<WeekRange> weekRangeList = new List<WeekRange>();
                WeekRange weekRange = new WeekRange();
    
                while ((startDateToCheck.Year <= endDate.Year) && (startDateToCheck.Month <= endDate.Month) && dateToCheck <= endDate)
                {
                    int week = 0;
    
                    while (startDateToCheck.Month == dateToCheck.Month && dateToCheck <= endDate)
                    {
                        week = week + 1;
                        dateRangeBegin = dateToCheck.AddDays(-(int)dateToCheck.DayOfWeek);
                        dateRangeEnd = dateToCheck.AddDays(6 - (int)dateToCheck.DayOfWeek);
    
                        if ((dateRangeBegin.Date < dateToCheck) && (dateRangeBegin.Date.Month != dateToCheck.Month))
                        {
                            dateRangeBegin = new DateTime(dateToCheck.Year, dateToCheck.Month, dateToCheck.Day);
                        }
    
                        if ((dateRangeEnd.Date > dateToCheck) && (dateRangeEnd.Date.Month != dateToCheck.Month))
                        {
                            DateTime dtTo = new DateTime(dateToCheck.Year, dateToCheck.Month, 1);
                            dtTo = dtTo.AddMonths(1);
                            dateRangeEnd = dtTo.AddDays(-(dtTo.Day));
                        }
                        if (dateRangeEnd.Date > endDate)
                        {
                            dateRangeEnd = new DateTime(dateRangeEnd.Year, dateRangeEnd.Month, endDate.Day);
                        }
                        weekRange = new WeekRange
                        {
                            StartDate = dateRangeBegin.ToShortDateString(),
                            EndDate = dateRangeEnd.ToShortDateString(),
                            Range = dateRangeBegin.Date.ToShortDateString() + '-' + dateRangeEnd.Date.ToShortDateString(),
                            Month = dateToCheck.Month,
                            Year = dateToCheck.Year,
                            Week = week
                        };
                        weekRangeList.Add(weekRange);
                        dateToCheck = dateRangeEnd.AddDays(1);
                    }
                    startDateToCheck = startDateToCheck.AddMonths(1);
                }
                return weekRangeList;
            }
