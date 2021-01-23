    internal class SelectEnumerable<TIn, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<TIn> BaseCollection { get; set; }
        private Func<TIn, TResult> Mapping { get; set; }
        internal SelectEnumerable(IEnumerable<TIn> baseCollection, 
                                  Func<TIn, TResult> mapping)
        {
            BaseCollection = baseCollection;
            Mapping = mapping;
        }
        public IEnumerator<TResult> GetEnumerator()
        {
            return new SelectEnumerator<TIn, TResult>(BaseCollection.GetEnumerator(), 
                                                      Mapping);
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
    internal class SelectEnumerator<TIn, TResult> : IEnumerator<TResult>
    {
        private IEnumerator<TIn> Enumerator { get; set; }
        private Func<TIn, TResult> Mapping { get; set; }
        internal SelectEnumerator(IEnumerator<TIn> enumerator, 
                                  Func<TIn, TResult> mapping)
        {
            Enumerator = enumerator;
            Mapping = mapping;
        }
        public void Dispose() { Enumerator.Dispose(); }
        public bool MoveNext() { return Enumerator.MoveNext(); }
        public void Reset() { Enumerator.Reset(); }
        public TResult Current { get { return Mapping(Enumerator.Current); } }
        object IEnumerator.Current { get { return Current; } }
    }
    internal static class MyExtensions
    {
        internal static IEnumerable<TResult> MySelect<TIn, TResult>(
            this IEnumerable<TIn> enumerable,
            Func<TIn, TResult> mapping)
        {
            return new SelectEnumerable<TIn, TResult>(enumerable, mapping);
        }
    }
