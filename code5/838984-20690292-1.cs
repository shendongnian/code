    public class Customer : ICloneable
    {
        private int CustomerID { get; set; }
        public Customer Clone()
        {
            return new Customer { CustomerID = this.CustomerID };
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
