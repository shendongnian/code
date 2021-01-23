    public class CharComparer : IEqualityComparer<char>
    {
         public bool Equals(char c1, char c2)
         {
              return char.ToLowerInvariant(c1) == char.ToLowerInvariant(c2);
         }
         public int GetHashCode(char c1)
         {
              return char.ToLowerInvariant(c1).GetHashCode();
         }
    }
