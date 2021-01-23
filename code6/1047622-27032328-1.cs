    public static class ListExtensions
    {
        public static void Resize<T>(this List<T> list, int count)
        {
            if (list == null || count < 0)
                throw new ArgumentException();
            int oldCount = list.Count;
            if (count > oldCount)
            {
                list.Capacity = count;
                for (int i = oldCount; i < count; i++)
                    list.Add(default(T));
            }
            else if (count < oldCount)
            {
                for (int i = oldCount - 1; i >= count; i--)
                    list.RemoveAt(i);
            }
        }
        public static void EnsureCount<T>(this List<T> list, int count)
        {
            if (list == null || count < 0)
                throw new ArgumentException();
            if (count > list.Count)
                list.Resize(count);
        }
    }
