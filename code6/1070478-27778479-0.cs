    public class MyValue<T>
    {
        private T value;
        private readonly Func<T, bool>[] contraints;
        public MyValue(
                T value,
                params Func<T, bool>[] contraints)
        {
            this.value = value;
            this.constraints = constraints;
            this.Validate();
        }
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                this.Validate();
            }
        }
        private Validate()
        {
            if (!this.constriants.All(c => c(this.value))
            {
                // throw some exception.
            }
        }
    }
