    public static class MyExtensions
    {
        public static void SetRangeValues<T>(this IList<T> source, int start, int end, T value)
        {
            if (start > 0 && end < source.Count)
            {
                for (int i = start; i <= end; i++)
                {
                    source[i] = value;
                }
            }
            
        }
    }
