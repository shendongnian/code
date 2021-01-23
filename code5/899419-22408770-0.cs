    // Here is a fix to your method. It would work if TKey values
    // cannot have underscores. In any event, it will be very slow.
    internal class ListKeyComparer<TKey> : IEqualityComparer<List<TKey>>
    {
      // Make a method that produces the key to avoid repeating yourself:
      private string MakeKey(List<TKey> key) {
        return String.Join("_", key);
      }
      public bool Equals(List<TKey> key1, List<TKey> key2)
      {
        return MakeKey(key1).Equals(MakeKey(key2));
      }
    
      public int GetHashCode(List<TKey> key)
      {
        return MakeKey(key).GetHashCode();
      }
    }
