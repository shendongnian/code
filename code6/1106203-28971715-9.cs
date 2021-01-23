    public static class RecordExtensions
    {
    
        private static Func<DateTime, DateTime>[] PeriodIncrementers = new Func<DateTime, DateTime>[]
        {
            (date) => date, // RepetitionType = 0
            (date) => date.AddDays(1), // RepetitionType = 1 (daily)
            (date) => date.AddDays(7), // RepetitionType = 2 (weekly)
            (date) => date.AddMonths(1), // RepetitionType = 3 (monthy)
            (date) => date.AddMonths(3), // RepetitionType = 4 (quarterly)
            (date) => date.AddMonths(6), // RepetitionType = 5 (semiannually)
            (date) => date.AddYears(1), // RepetitionType = 6 (annually)
            (date) => date.AddYears(2), // RepetitionType = 7 (biannually)
        };
    
        private static Func<DateTime, DateTime>[] DefaultDateLimiters = new Func<DateTime, DateTime>[]
        {
            (date) => date, // RepetitionType = 0
            (date) => (new DateTime(date.Year, date.Month, 1)).AddMonths(1).AddDays(-1), // RepetitionType = 1 (daily). Limit: last day of month
            (date) => date.AddDays(7 * 10 ), // RepetitionType = 2 (weekly). Limit: 10 weeks
            (date) => date.AddYears(1), // RepetitionType = 3 (monthy). Limit: 1 year
            (date) => date.AddYears(2), // RepetitionType = 4 (quarterly). Limit:  2 year
            (date) => date.AddYears(4), // RepetitionType = 5 (semiannually). Limit: 4 years 
            (date) => date.AddYears(8), // RepetitionType = 6 (annually). Limit: 8 years
            (date) => date.AddYears(16), // RepetitionType = 7 (biannually). Limit: 16 years
    
        };    
    
        public static IEnumerable<Record> ExpandRepetitions(this IEnumerable<Record> records)
        {
            var concatenation = Enumerable.Empty<Record>();
            foreach (var record in records)
            {
                concatenation = concatenation.Concat(ExpandRepetition(record));
            }
            return concatenation;
        }
    
        private static IEnumerable<Record> ExpandRepetition(Record record)
        {
            yield return record;
            var previousRecord = record;
            DateTime endDate = record.RepeatingEndDate == null ? DefaultDateLimiters[record.RepetitionType](record.Date) : record.RepeatingEndDate.Value;
            var incrementer = PeriodIncrementers[record.RepetitionType];
            if (record.IsRepeatable)
            {
                DateTime date = incrementer(previousRecord.Date);
                while (date <= endDate)
                {
                    var newRecord = new Record
                    {
                        Date = date,
                        IsRepeatable = previousRecord.IsRepeatable,
                        Name = previousRecord.Name,
                        RepeatingEndDate = previousRecord.RepeatingEndDate,
                        RepetitionType = previousRecord.RepetitionType
                    };
                    date = incrementer(newRecord.Date);
                    yield return newRecord;
                    previousRecord = newRecord;
                }
            }
        }
    }
