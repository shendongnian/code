    public static class MyExtensions
    {
        public static IEnumerable<long> Range(long start, long count)
        {
            for (long i = start; i < start + count; i++)
            {
                yield return i;
            }
        } 
    }
