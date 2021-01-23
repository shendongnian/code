    public class OrderAttribute : Attribute
    {
        public OrderAttribute(int value)
        {
            this.Value = value;
        }
        public int Value { get; private set; }
    }
