    namespace Extensions
    {
        public static class ArrayExtension
        {
            public static IEnumerable<int> GetIndicesOf<T>(this T[] target, T val, int start = 0)
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                for (int i = start; i < target.Length; i++)
                {
                    if (comparer.Equals(target[i], val))
                    {
                        yield return i;
                    }
                }
            }
        }
    }
