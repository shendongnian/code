    public static class MoreEnumerable
    {
        public static bool NullRespectingSequenceEqual<T>(
            this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            return first.SequenceEqual(second);
        }
    }
