    public class KScheduleComparer : IEqualityComparer<KeywordSchedule>
    {
        public bool Equals(KeywordSchedule x, KeywordSchedule y)
        {
            return x.Id == y.Id;                
        }
        public int GetHashCode(KeywordSchedule obj)
        {
            return obj.GetHashCode();
        }
    }
