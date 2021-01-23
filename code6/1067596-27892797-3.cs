    public class Period : IEnumerable<DateTime>
    {
        public Period(DateTime firstDay, DateTime lastDay)
        {
            this.PeriodStart = firstDay;
            this.PeriodEnd = lastDay;
        }
    
        public DateTime PeriodStart { get; set; }
    
        public DateTime PeriodEnd { get; set; }
           
        public IEnumerator<DateTime> GetEnumerator()
        {
            yield return PeriodStart;
            yield return PeriodEnd;
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
