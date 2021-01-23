    public static class DatabaseHelper {
 
      public static void Apply<T>(this IEnumerable<T> collection, Action<T> action) {
         if (collection == null) { // Sanity check
            return;
         }
         foreach (var item in collection) {
            action(item);
         }
      }
    }
