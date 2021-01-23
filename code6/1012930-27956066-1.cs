    public class BasicRestriction<T> : IRestriction
    {
        public T Value { get; set; }
        public BasicRestriction()
        {
        }
        public BasicRestriction(T value)
        {
            Value = value;
        }
    }
