        public DateTime GetNextValidDate(DateTime date)
        {
            var validDays = new List<short> { 23, 27, 29 };
            var nextDay = validDays.FirstOrDefault(n => date.Day >= n);
            if (nextDay != default(int))
            {
                // The next valid day is in the current month
                return date.AddDays(nextDay - date.Day);
            }
            // The next valid day is next month
            nextDay = validDays.First();
            return new DateTime(date.Year, date.Month, nextDay, date.Hour, date.Minute, date.Second);
        }
