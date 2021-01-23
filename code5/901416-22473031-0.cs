     public static void RemoveAll<T>(
        this ICollection<T> source, IEnumerable<T> itemsToRemove)
     {
         if (source == null)
             throw new ArgumentNullException("source");
         foreach(var item in itemsToRemove)
             source.Remove(item);
     }
