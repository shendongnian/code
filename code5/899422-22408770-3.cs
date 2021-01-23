    internal class ListKeyComparer<TKey> : IEqualityComparer<List<TKey>>
    {
      public bool Equals(List<TKey> key1, List<TKey> key2)
      {
        return key1.SequenceEqual(key2);
      }
    
      public int GetHashCode(List<TKey> key)
      {
        return key.Aggregate((p, v) => 31*p + v.GetHashCode());
      }
    }
