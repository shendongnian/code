    public class Duration
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        
        public Duration(DateTime start, DateTime end)
        {
            if (start > end) throw new ArgumentException("start should be before end");
            Start = start;
            End = end;
        }
        
        public static Duration CreateFromDates(DateTime x, DateTime y, params DateTime[] others)
        {
            var all = others.Concat(new[] { x, y });
            var start = all.Min();
            var end = all.Max();
            return new Duration(start, end);
        }
    }
    
    public class SomeClass
    {
        public DateTime ValidFrom { get; }
        public DateTime ExpirationDate { get; }
    
        public SomeClass(Duration duration)
        {
            ValidFrom = duration.Start;
            ExpirationDate = duration.End;
        }
    }
