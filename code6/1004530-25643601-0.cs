        private static void Main(string[] args)
        {
            var columns = new List<Column>();
            var dateRanges = new List<DateRange>()
            {
                new DateRange(new DateTime(2013, 09, 03), new DateTime(2014, 09, 03))
            };
            var result = columns.GroupBy(
                column => dateRanges.FirstOrDefault(dr => dr.IsInRange(column.Date)),
                (dr, drc) => new KeyValuePair<DateRange, int>(dr, drc.Sum(v => v.Value)));
        }
        public struct DateRange
        {
            public DateRange(DateTime from, DateTime to)
                : this()
            {
                From = from;
                To = to;
            }
            public bool IsInRange(DateTime date)
            {
                return date >= From && date <= To;
            }
            public DateTime From { get; private set; }
            public DateTime To { get; private set; }
        }
        public class Column
        {
            public int Value { get; set; }
            public DateTime Date { get; set; }
        }
