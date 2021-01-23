     public class MyCompare : IEqualityComparer<SearchResult>
        {
            public bool Equals(SearchResult x, SearchResult y)
            {
                return (x.First == y.First) && ((x.Second == y.Second));
            }
    
    
            public int GetHashCode(SearchResult obj)
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + obj.First.GetHashCode();
                    hash = hash * 23 + obj.Second.GetHashCode();
                    return hash;
                }
            }
    }
