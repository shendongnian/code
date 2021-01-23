        private DateTime? ParseMe(string s)
        {
            var split = s.Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries);
            var year = int.Parse(split[split.Count()-1]);
            var day = int.Parse(split[2]);
            var month = split[1];
            int monthInDigit = DateTime.ParseExact(month, "MMM", CultureInfo.InvariantCulture).Month;
            return new DateTime(year, monthInDigit, day);
        }
