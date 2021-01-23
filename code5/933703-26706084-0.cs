    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;
        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }
        public TestDbAsyncEnumerator(Func<IEnumerator<T>> valueFunction)
        {
            _inner = valueFunction();
        }
        public void Dispose()
        {
            _inner.Dispose();
        }
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }
        public T Current
        {
            get { return _inner.Current; }
        }
        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }
