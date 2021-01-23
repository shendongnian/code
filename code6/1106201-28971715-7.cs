    public static class RecordExtensions
    {
    
        public static Func<DateTime, DateTime>[] PeriodIncrementers = new Func<DateTime, DateTime>[]
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
            var incrementer = PeriodIncrementers[record.RepetitionType];
            if (record.IsRepeatable)
            {
                DateTime date = incrementer(previousRecord.Date);
                while (date <= previousRecord.RepeatingEndDate)
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
