        public IEnumerable<DateTime> WithinTimeRange(DateTime begin, DateTime end)
        {
            var dates = from a in context.Items
                        where a.Timestamp.Month.Equals(begin.Month) && a.Timestamp.Day 
            >= begin.Day && a.Timestamp.Month.Equals(end.Month) && a.Timestamp.Day <= end.Day
                        select a;
    
            return dates.ToList();
        } 
