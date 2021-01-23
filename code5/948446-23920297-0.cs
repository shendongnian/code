    public class SetComparer : IEqualityComparer<IEnumerable<int>>
    {
        public bool Equals(IEnumerable<int> x, IEnumerable<int> y)
        {
            return Object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }
    
        public int GetHashCode(IEnumerable<int> set)
        {
            if (set == null) return 0;
    	    
            //if you only want one of these 1,2,3 vs 3,2,1
            //plug .OrderBy(x => x) before the Aggregate
            return set.Aggregate(19, (s,i) => s * 31 + i);
        }
    }
