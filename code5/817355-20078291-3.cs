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
        public static bool TryParse(string s, out YearWeek result)
        {
            var match = parseRegex.Match(s);
            if (match.Success)
            {
                result = new YearWeek(int.Parse(match.Groups["year"].Value),
                                    int.Parse(match.Groups["week"].Value));
                return true;
            }
            else
            {
                result = default(YearWeek);
                return false;
            }
        }
        public static YearWeek Parse(string s)
        {
            YearWeek result;
            if (TryParse(s, out result))
                return result;
            else
                throw new ArgumentException("s");
        }
        public override string ToString()
        {
            return string.Format("{0:0000}-W{1:00}", Year, Week);
        }
    }
