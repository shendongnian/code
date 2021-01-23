    class AP1P2Comparer : IEqualityComparer<A>
    {
    
        public bool Equals(A a1, A a2)
        {
            return a1.P1 == a2.P1 && a1.P2 == a2.P2
        }
    
    
        public int GetHashCode(A a)
        {
            int hCode = a.P1.GetHashCode() ^ a.P2.GetHashCode();
            return hCode.GetHashCode();
        }
    
    }
    //...
    var result = list.Distinct(new AP1P2Comparer()).Select(a => new Id { Main = a.P1, SubMain = a.P2 }).ToList();
