    class NullsAtEndComparer<T> : IComparer<T> where T : class
    {
        private static readonly IComparer<T> _baseComparer = Comparer<T>.Default;
        private readonly bool _ascending;
        public NullsAtEndComparer(bool ascending = true)
        {
            _ascending = ascending;
        }
        public int Compare(T t1, T t2)
        {
            if (object.ReferenceEquals(t1, t2))
            {
                return 0;
            }
            if (t1 == null)
            {
                return 1;
            }
            if (t2 == null)
            {
                return -1;
            }
            return _ascending ? _baseComparer.Compare(t1, t2) : _baseComparer.Compare(t2, t1);
        }
    }
