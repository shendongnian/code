        public static void FindLastSaturday(int month, int startYear, int numberOfYears)
        {
            var dates = Enumerable.Range(startYear, numberOfYears)
                .Select(q => FilterFunc(new DateTime(q, month, CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(q, month))));
            foreach (DateTime lastSaturday in dates)
            {
                Console.WriteLine(lastSaturday.ToString("R"));
            }
        }
        private static DateTime FilterFunc(DateTime arg)
        {
            if (arg.DayOfWeek == DayOfWeek.Saturday)
            {
                return arg;
            }
            return FilterFunc(arg.AddDays(-1));
        }
