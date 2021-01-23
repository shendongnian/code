    public class ComputedBoolean : IComputableBoolean
    {
        public ComputedBoolean(bool value)
        {
            Value = value;
        }
        public bool Value { get; private set; }
        public bool ValueComputed { get { return true; } }
    }
