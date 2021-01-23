    public static class IEnumerableExtensionMethods
    {
        public static ICollection<T> ForEachAndAdd<T>(this IEnumerable<T> self,
                                                      ICollection<T> other,
                                                      Func<T, T, bool> predicate) where T : class
        {
            foreach(var h1 in self) 
            {
               if(other.FirstOrDefault(h2 => predicate(h1, h2)) == null)
                   other.Add(h1);
            }
            return other;
        }
    }
