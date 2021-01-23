    public sealed class LookupEnumerator<T, Y> : IEnumerator<Y>
    {
        private readonly IEnumerator<T> input;
        private readonly Func<T, Y> map;
        private readonly Dictionary<Y, T> reverse = new Dictionary<Y, T>();
        public LookupEnumerator(IEnumerator<T> input, Func<T, Y> map)
        {
            this.input = input;
            this.map = map;
        }
        public Y Current
        {
            get;
            private set;
        }
        public bool TryGetInputValue(Y value, out T inputValue)
        {
            return reverse.TryGetValue(value, out inputValue);
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (!input.MoveNext())
            {
                return false;
            }
            Current = map(input.Current);
            reverse.Add(Current, input.Current);
            return true;
        }
        // ... rest of IEnumerator implementation
