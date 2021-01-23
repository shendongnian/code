    public class DecisionResult<T>
    {
        private readonly T value;
        public readonly bool HasValue;
        internal DecisionResult(T value)
        {
            this.value = value;
            HasValue = true;
        }
        internal DecisionResult()
        {
        }
        public T Value
        {
            get
            {
                if (HasValue)
                {
                    return value;
                }
                else
                {
                    throw new DecisionFailedException();
                }
            }
        }
    }
