    public class CombinationComparer : IEqualityComparer<Combination>
    {
         public bool Equals(Combination c1, Combination c2)
         {
             if (ReferenceEquals(c1,c2))
             {
                  return true;
             }
             if (c1 == null || c2 == null)
             {
                  return false;
             }
             return (c1.CombOne == c2.CombOne && c1.CombTwo == c2.CombTwo)
                        || (c1.CombOne == c2.CombTwo && c1.CombTwo == c2.CombOne);
        }
    }
