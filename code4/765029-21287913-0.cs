    public static class ExtensionMethods
    {
        public static IEnumerable<T>  ReverseArray<T>(this T[] source)
        {
            for (int i = source.Length - 1; i >= 0; i--)
            {
                yield return source[i];
            }
        }
        public static T[] EnumerableToArray<T>(this IEnumerable<T> source)
        {
            var array = new T[source.Count()];
            int k = 0;
            foreach (var n in source)
            {
                array[k++] = n;
            }
            return array;
        }
    }
