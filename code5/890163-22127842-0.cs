    public class LimitedEnumerator : IEnumerator
    {
        protected readonly IEnumerator _enumerator;
        private readonly int _limit;
        private int _index;
        public LimitedEnumerator(IEnumerator enumerator, int limit)
        {
            if (enumerator == null) 
                throw new ArgumentNullException("enumerator");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            _enumerator = enumerator;
            _limit = limit;
            _index = 0;
        }
        public bool MoveNext()
        {
            var moveNext = _enumerator.MoveNext();
            if (moveNext)
                Current = _enumerator.Current;
            return moveNext && ++_index <= _limit;
        }
        public void Reset()
        {
            _index = 0;
            _enumerator.Reset();
            Current = _enumerator.Current;
        }
        public object Current { get; private set; }
    }
    public class LimitedEnumerator<T> : LimitedEnumerator, IEnumerator<T>
    {
        public LimitedEnumerator(IEnumerator<T> enumerator, int limit) 
            : base(enumerator, limit)
        {
        }
        public void Dispose()
        {
            ((IEnumerator<T>)_enumerator).Dispose();
        }
        T IEnumerator<T>.Current
        {
            get
            {
                return (T) Current;
            }
        }
    }
