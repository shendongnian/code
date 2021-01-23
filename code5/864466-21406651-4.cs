    public class WhereEnumerableIterator<T> : IEnumerable<T>, IDisposable
    {
        private IEnumerator<T> _enumerator;
        private Func<T,bool> _predicate;
        public WhereEnumerableIterator(IEnumerable<T> source, Func<T,bool> predicate)
        {
            _predicate = predicate;
            _enumerator = source.GetEnumerator();
        }
        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_predicate(_enumerator.Current))
                {
                    Current = _enumerator.Current;
                    return true;
                }
            }
            return false;
        }
        public T Current { get; private set; }
        public void Dispose()
        {
            if (_enumerator != null)
                _enumerator.Dispose();
        }
    }
