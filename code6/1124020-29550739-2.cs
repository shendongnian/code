    public static class MyInfiniteEnumerable
    {
        public static IEnumerable<int> GetIt()
        {
            var x = 0;
            while (true)
                yield return x + 1;
        }
    }
