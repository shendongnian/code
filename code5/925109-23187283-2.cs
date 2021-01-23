    public class CustomerAddress : EntityBase<CustomerAddress>, IAddress
    {
        public virtual int CustomerId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual string Nickname { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Line3 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
    }
