    class DateTimeByDayComparer : IEqualityComparer<DateTime>
    {
           public bool Equals(DateTime x, DateTime y)
           {
               return x.Day == y.Day;
           }
    }
    
    public List<DateTime> DistinctNoticeDates()
    {
         var comparer = new DateTimeByDayComparer();
         return this.GetTable<Notice>().OrderByDescending(n => n.Notice_DatePlanned).Distinct(comparer).ToList();
    }
