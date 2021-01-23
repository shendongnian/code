    public class ActivitiesActivityEqualityComparer
        : IEqualityComparer<ActivitiesActivity>
    {
        public bool Equals(ActivitiesActivity x, ActivitiesActivity y)
        {
            ...
        }
        public int GetHashCode(ActivitiesActivity activity)
        {
            ...
        }
    }
