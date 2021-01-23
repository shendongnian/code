    public static class Extensions
    {
        public static IEnumerable<T> EndToEnd(this IReadOnlyList<out T> source)
        {
            var length = source.Count;
            var returned = 0;
            var offset = 0;
            while (returned < length)
            {
                yield return source[offset];
                returned++;
                if (returned == length)
                {
                   break;
                }
               
                yield return source[length - offset - 1];
                returned++;
                offset++'
            }
        }
    }
