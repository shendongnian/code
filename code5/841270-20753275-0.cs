    static class InfiniteContinuingSequence
    {
        static int x = 0;
        static IEnumerable<int> GetNumbers()
        {
            while (true)
            {
                yield return x++;
            }
        }
    }
