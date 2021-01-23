    public struct DecisionResult<T>
    {
        private readonly T value;
        public readonly bool HasValue;
        internal DecisionResult(bool hasValue, T value = default(T))
        {
            this.value = value;
            HasValue = hasValue;
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
