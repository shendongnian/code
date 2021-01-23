    public struct YearWeek
    {
        private static readonly Regex parseRegex =
                                new Regex(@"^(?<year>\d{4})-W?(?<week>\d{2})$");
        public int Year { get; private set; }
        public int Week { get; private set; }
        public YearWeek(int year, int week) : this()
        {
            this.Year = year;
            this.Week = week;
        }
        public static YearWeek Parse(string s)
        {
            var match = parseRegex.Match(s).Dump();
            return new YearWeek(int.Parse(match.Groups["year"].Value),
                                int.Parse(match.Groups["week"].Value));
        }
        public override string ToString()
        {
            return string.Format("{0:0000}-W{1:00}", Year, Week);
        }
    }
