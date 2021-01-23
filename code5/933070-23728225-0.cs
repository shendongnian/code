    internal sealed class LazyToString
    {
        private readonly Func<object> valueGetter;
        public LazyToString(Func<object> valueGetter)
        {
            this.valueGetter = valueGetter;
        }
        public override string ToString()
        {
            return this.valueGetter().ToString();
        }
    }
