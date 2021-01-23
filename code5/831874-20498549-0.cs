    public class MyDanishStringComparer : IEqualityComparer<string>
    {
      public bool Equals(string x, string y)
      {
        return x.Replace("Å", "Aa").Equals(y);
      }
    }
