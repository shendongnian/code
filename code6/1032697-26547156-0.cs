      public static class PredicateExtensions
      {
        public static Predicate<T> Or<T> (this Predicate<T> p1, Predicate<T> p2)
        {
          return obj => p1(obj) || p2(obj);
        }
        
        public static Predicate<T> And<T> (this Predicate<T> p1, Predicate<T> p2)
        {
          return obj => p1(obj) && p2(obj);
        }
        public static Predicate<T> False<T> () { return obj => false; }
        public static Predicate<T> True<T>  () { return obj => true; }
    
        public static Predicate<T> OrAll<T> (IEnumerable<Predicate<T>> conditions)
        {
          Predicate<T> result = PredicateExtensions.False<T>();
          foreach (Predicate<T> cond in conditions)
            result = result.Or<T>(cond);
          return result;
        }
    
        public static Predicate<T> AndAll<T> (IEnumerable<Predicate<T>> conditions)
        {
          Predicate<T> result = PredicateExtensions.True<T>();
          foreach (Predicate<T> cond in conditions)
            result = result.And<T>(cond);
          return result;
        }
      }
