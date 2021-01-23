    public class ScheduledTimeComparer : IEqualityComparer<ScheduledTime>
    {
        public bool Equals(ScheduledTime x, ScheduledTime y)
        {
            if (x == y) return true;
            if (x == null) return false;
            return x.Start == y.Start && x.End == y.End;
        }
    
        public int GetHashCode(ScheduledTime schedule)
        {
            unchecked
            {
                return schedule.Start * 31 + schedule.End;
            }
        }
    }
