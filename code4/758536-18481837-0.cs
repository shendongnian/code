    public static class Enumerable
    {
        public static IEnumerable<T> Return<T>(T value)
        {
            yield return value;
        }
        public static IEnumerable<T> Concat<T>(params IEnumerable<T>[] lists)
        {
            foreach (var values in lists)
                foreach (var value in values)
                    yield return value;
        }
    }
