    interface IMonoid<T>
    {
        T MAppend(IMonoid<T> other);
    }
    class Test
    {
        public static void runTest<T>(IEnumerable<IMonoid<T>> list)
            where T : IMonoid<T>
        {
            list.Aggregate((x, ac) => ac.MAppend(x));
        }
    }
