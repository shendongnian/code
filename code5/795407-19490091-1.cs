    class AP1P2Comparer : IEqualityComparer<A>
    {
    
        public bool Equals(A a1, A a2)
        {
            return a1.P1 == a2.P1 && a1.P2 == a2.P2
        }
    
    
        public int GetHashCode(A a)
        {
           unchecked 
           {
             int hash = 17;
             hash = hash * 23 + a.T1.GetHashCode();
             hash = hash * 23 + a.T2.GetHashCode();
             return hash;
           }
        }
    
    }
    //...
    var result = list.Distinct(new AP1P2Comparer())
                     .Select(a => new Id { Main = a.P1, SubMain = a.P2 })
                     .ToList();
