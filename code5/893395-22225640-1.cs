        public IEnumerable<Item> WithinTimeRange(DateTime begin, DateTime end)
        {
            var items = from a in context.Items
                        where a.Timestamp.Month.Equals(begin.Month) && a.Timestamp.Day 
            >= begin.Day && a.Timestamp.Month.Equals(end.Month) && a.Timestamp.Day <= end.Day
                        select a;
    
            return items.ToList();
        } 
