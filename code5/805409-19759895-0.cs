    class DateDiff
     {
        public DateDiff(DateTime startDate, DateTime endDate)
        {
            GetYears(startDate, endDate); // Get the Number of Years Difference between two dates
            GetMonths(startDate.AddYears(YearsDiff), endDate); // Getting the Number of Months Difference but using the Years difference earlier
            GetDays(startDate.AddYears(YearsDiff).AddMonths(MonthsDiff), endDate); // Getting the Number of Days Difference but using Years and Months difference earlier
        }
        void GetYears(DateTime startDate, DateTime endDate)
        {
            int Years = 0;
            // Traverse until start date parameter is beyond the end date parameter
            while (endDate.CompareTo(startDate.AddYears(++Years))>=0) {}
            YearsDiff = --Years; // Deduct the extra 1 Year and save to YearsDiff property
        }
        void GetMonths(DateTime startDate, DateTime endDate)
        {
          // Provide your own code here
        }
        void GetDays(DateTime startDate, DateTime endDate)
        {
          // Provided your own code here
        }
        public int YearsDiff { get; set; }
        public int MonthsDiff { get; set; }
        public int DaysDiff { get; set; }
     }
