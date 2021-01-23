    // Defines a comparer to create a sorted set 
    // that is sorted by time. 
    public class ByTime : IComparer<SameTimeTaskList>
    {
        public int Compare(SameTimeTaskList x, SameTimeTaskList y)
        {
            return x.time.CompareTo(y.time);
        }
    }
