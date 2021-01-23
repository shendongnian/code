    // Better make sure T is immutable too, else set hashes could change
    public class SetofSets<T>
    {
        private class HashSetComparer : IEqualityComparer<HashSet<T>>
        {
            public int GetHashCode(HashSet<T> x)
            {
                return x.Aggregate(1, (code,elt) => code ^ elt.GetHashCode());
            }
		
            public bool Equals(HashSet<T> x, HashSet<T> y)
            {
                if (x==null)
                    return y==null;
                return x.SetEquals(y);
            }
        }
	
        private HashSet<HashSet<T>> setOfSets;
        public SetofSets()
        {
            setOfSets = new HashSet<HashSet<T>>(new HashSetComparer());
        }
	
        public void Add(HashSet<T> set)
        {
            setOfSets.Add(new HashSet<T>(set));
        }
	
        public bool Contains(HashSet<T> set)
        {
            return setOfSets.Contains(set);
        }
    }
