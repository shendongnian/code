    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> source,
        Func<T, bool> predicate)
    {
        return new WhereEnumerable<T>(source, predicate);
    }
    public class WhereEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> source;
        private Func<T, bool> predicate;
        public WhereEnumerable(IEnumerable<T> source, Func<T, bool> predicate)
        {
            this.source = source;
            this.predicate = predicate;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new WhereEnumerator<T>(source.GetEnumerator(), predicate);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class WhereEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> source;
        private Func<T, bool> predicate;
        public WhereEnumerator(IEnumerator<T> source, Func<T, bool> predicate)
        {
            this.source = source;
            this.predicate = predicate;
        }
        public T Current { get; private set; }
        public void Dispose()
        {
            source.Dispose();
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            while (source.MoveNext())
                if (predicate(source.Current))
                {
                    Current = source.Current;
                    return true;
                }
            return false;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
