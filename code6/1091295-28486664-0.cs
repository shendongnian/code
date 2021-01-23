    public class StartsWithEqualityComparer : IEqualityComparer<String>
    {
       #region IEqualityComparer implementation
       public bool Equals (string x, string y)
       {
          return y.StartsWith (x);
       }
       public int GetHashCode (string obj)
       {
          return 0;
       }
 
       #endregion
    }
