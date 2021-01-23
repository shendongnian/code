    public class Address
    {
        public virtual IList<AddressCompany> Companies { get; set; }
        ...
    }
    public class Company
    {
        public virtual IList<AddressCompany> Addresses { get; set; }
        ...
    }
