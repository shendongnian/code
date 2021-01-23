    // You could do this without the constraint, with a bit of extra work.
    public class ReadOnlyAfterWrite<T> where T : struct
    {
        private T? value;
        private readonly string property;
        private readonly string type;
        public ReadOnlyAfterWrite(string property, string type)
        {
            this.property = property;
            this.type = type;
        }
        public T Value
        {
            get
            {
                if (value == null)
                {
                    // Use type and property here
                    throw new InvalidOperationException(...);
                }
                return (T) value;
            }
            set { this.value = value; }
        }
    }
    public class ContractClass
    {
        // This is what I'd do in C# 6. Before that, probably just use string literals.
        private readonly ReadOnlyAfterWrite<int> delta =
            new ReadOnlyAfterWrite(nameof(Delta), nameof(ContractClass));
        public int Delta
        {
            get { return delta.Value; }
            set { delta.Value = value; }
        }
    }
