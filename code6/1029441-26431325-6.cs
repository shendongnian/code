    public class Season
    {
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
        public int Rate { get; set; }
        // Instance method
        public bool DateIsInSeason(DateTime date)
        {
            return DateIsInSeason(date, this);
        }
        // Static method
        public static bool DateIsInSeason(DateTime date, Season season)
        {
            // Rules: (remember a season may start in Dec and end in Jan,
            //        so you cant just check if the date is between them!)
            // 1. If the start and end month are the same,
            //    return true if the month is equal to start (or end) month
            //    AND the day is between start and end days.
            // 2. If the date is in the same month as the start month, 
            //    retrun true if the day is greater than or equal to start day.
            // 3. If the date is in the same month as the end month, 
            //    retrun true if the day is less than or equal to end day.
            // 4. If the StartMonth is less than the EndMonth, 
            //    retrun true if the month is between them.
            // 5. Otherwise, return true if month is NOT between them.
            if (season.StartMonth == season.EndMonth)
                return date.Month == season.StartMonth && 
                       date.Day >= season.StartDay && 
                       date.Day <= season.EndDay;
            if (date.Month == season.StartMonth) 
                return date.Day >= season.StartDay;
            if (date.Month == season.EndMonth) 
                return date.Day <= season.EndDay;
            if (season.StartMonth <= season.EndMonth) 
                return date.Month > season.StartMonth && date.Month < season.EndMonth;
            return date.Month < season.EndMonth || date.Month > season.StartMonth;
        }
    }
