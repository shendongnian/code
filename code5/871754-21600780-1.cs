        public static DateTime GetNextValidDate(DateTime date)
        {
            var validDays = new List<short> { 23, 27, 29 };
            var nextDay = validDays.FirstOrDefault(n => n >= date.Day);
            if (nextDay != default(int))
            {
                // The next valid day is in the current month
                return date.AddDays(nextDay - date.Day);
            }
            // The next valid day is next month
            nextDay = validDays.Min();
            return new DateTime(date.Year, date.Month, nextDay, date.Hour, date.Minute, date.Second).AddMonths(1);
        }
