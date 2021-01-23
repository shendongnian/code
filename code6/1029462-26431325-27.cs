    public class Season
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rate { get; set; }
        public bool ContainsDate(DateTime date)
        {
            // Assumption: Year is ignored - seasons are considered 
            //             to start and end on the same date each year
            //
            // Rules: (remember a season may start in Dec and end in Jan,
            //         so you cant just check if the date is greater than
            //         the start or less than the end!)
            // 
            // 1. If the start and end month are the same,
            //    return true if the month is equal to start (or end) month
            //    AND the day is between start and end days.
            // 2. If the date is in the same month as the start month, 
            //    return true if the day is greater than or equal to start day.
            // 3. If the date is in the same month as the end month, 
            //    return true if the day is less than or equal to end day.
            // 4. If the StartMonth is less than the EndMonth, 
            //    return true if the month is between them.
            // 5. Otherwise, return true if month is NOT between them.
            if (StartDate.Month == EndDate.Month)
                return date.Month == StartDate.Month &&
                       date.Day >= StartDate.Day &&
                       date.Day <= EndDate.Day;
            if (date.Month == StartDate.Month)
                return date.Day >= StartDate.Day;
            if (date.Month == EndDate.Month)
                return date.Day <= EndDate.Day;
            if (StartDate.Month <= EndDate.Month)
                return date.Month > StartDate.Month && date.Month < EndDate.Month;
            return date.Month < EndDate.Month || date.Month > StartDate.Month;
        }
    }
