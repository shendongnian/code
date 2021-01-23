    public static class Extensions
    {
        public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> pred)
        {
            var toBeRemoved = collection.Where(pred).ToArray();
            foreach (var item in toBeRemoved)
                collection.Remove(item);
        }
    }
