    public static class MyExtensions
    {
        public static bool AddAll<T>(this ISet<T> list, IEnumerable<T> items)
        {
            // some very simple implementation:
            bool success = true;
            foreach (var item in items)
            {
                success &= list.Add(item);
            }
            return success;
        }
    }
