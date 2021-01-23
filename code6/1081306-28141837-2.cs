    public static class MyEnumerableExtensions
    {
        public static T Min<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            T min = default (T);
            bool initialized = false;
            foreach (T elem in list)
            {
                if (!initialized)
                {
                    min = elem;
                    initialized = true;
                }
                else if (min == null) // Do not compare with null, reset min
                {
                    min = elem;
                }
                else if (elem != null && min.CompareTo(elem) > 0) // Compare only when elem is not null
                {
                    min = elem;
                }
            }
            if (!initialized)
            {
                throw new InvalidOperationException("list is empty");
            }
            return min;
        }
    }
