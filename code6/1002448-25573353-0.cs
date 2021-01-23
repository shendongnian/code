    public static IEnumerable<T> ThereCanBeOnlyOne<T>(this IEnumerable<T> source)
    {
        return new SingleEnumerable<T>(source);
    }
    private class SingleEnumerable<T> : IEnumerable<T>
    {
        private bool hasRun = false;
        private IEnumerable<T> wrapped;
        public SingleEnumerable(IEnumerable<T> wrapped)
        {
            this.wrapped = wrapped;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (hasRun)
                throw new InvalidOperationException(
                    "Sequence cannot be enumerated multilpe times");
            else
            {
                hasRun = true;
                return wrapped.GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
