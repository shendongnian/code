    public sealed class Customer : ICloneable
    {
        private int CustomerID { get; set; }
    
        public Customer Clone()
        {
            return (customer)this.MemberwiseClone();
        }
    
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
