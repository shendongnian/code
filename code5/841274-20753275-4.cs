    static class InfiniteContinuingSequence
    {
        static int x = 0;
        public static IEnumerable<int> GetNumbers()
        {
            while (true)
            {
                yield return x++;
            }
        }
    }
