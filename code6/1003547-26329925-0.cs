    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;
        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }
        public void Dispose()
        {
            _inner.Reset();
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
