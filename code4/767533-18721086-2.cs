    public class KeywordScheduleComparer : IEqualityComparer<IEnumerable<KeywordSchedule>>
    {
        public bool Equals(IEnumerable<KeywordSchedule> x, IEnumerable<KeywordSchedule> y)
        {
            return Object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y, new KScheduleComparer()));
        }
        public int GetHashCode(IEnumerable<KeywordSchedule> obj)
        {
            if (obj == null)
                return 0;
            return unchecked(obj.Select(e => e.GetHashCode()).Aggregate(0, (a, b) => a + b));  // BAD
        }
    }
