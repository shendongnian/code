    public static class IEnumerableExtensionMethods
    {
        public static void ForEachAndAdd<T>(this IEnumerable<T> self,
                                            ICollection<T> other,
                                            Func<T, bool> predicate)
        {
            foreach(var t in self) 
            {
               if(!predicate(t))
                   other.Add(t);
            }
        }
    }
