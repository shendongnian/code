    public static class DateTimeHelpers
    {
        public static bool Between(this DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            return dateTime >= startDate && dateTime <= endDate;
        }
    }
    ...
    list.Where(x => x.Date.Between(StartDate, EndDate));
