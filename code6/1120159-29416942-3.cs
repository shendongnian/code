    public class Lazy<T>
    {
        private object key = new object();
        private Func<T> generator;
        private T value;
        public Lazy(Func<T> generator)
        {
            this.generator = generator;
        }
        private volatile bool hasComputedValue;
        public bool HasComputedValue { get { return hasComputedValue; } }
        public T Value
        {
            get
            {
                lock (key)
                {
                    if (HasComputedValue)
                        return value;
                    else
                    {
                        value = generator();
                        hasComputedValue = true;
                        return value;
                    }
                }
            }
        }
    }
