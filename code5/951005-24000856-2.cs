    public class DeferredBoolean : IComputableBoolean
    {
        private Func<bool> generator;
        private bool? value = null;
        public DeferredBoolean(Func<bool> generator)
        {
            this.generator = generator;
        }
        public bool Value
        {
            get
            {
                if (value != null)
                    return value.Value;
                else
                {
                    value = generator();
                    return value.Value;
                }
            }
        }
        public bool ValueComputed { get { return value != null; } }
    }
