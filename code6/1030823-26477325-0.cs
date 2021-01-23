    public class TrueReadOnlyCollection<T> : ICollection<T>
    {
        private ICollection<T> _original;
        public TrueReadOnlyCollection(ICollection<T> original)
        {
            _original = original;
        }
        public IEnumerable<T> GetEnumerator()
        {
            foreach (T t in _original)
            {
                yield return t;
            }
        }
        public int Count { get { return _original.Count; } }
        public bool IsReadOnly { get { return true; } }
        // etc. ... the rest is left as an exercise for the reader...  :)
    }
