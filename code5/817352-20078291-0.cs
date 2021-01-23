    public struct YearWeek
    {
        public int Year { get; private set; }
        public int Week { get; private set; }
        public YearWeek(int year, int week) : this()
        {
            this.Year = year;
            this.Week = week;
        }
        public YearWeek Parse(string s)
        {
            // parse...
        }
        public override string ToString()
        {
            return string.Format("{0:0000}-W{1:00}", Year, Week);
        }
    }
