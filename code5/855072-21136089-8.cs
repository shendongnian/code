    public class AddressCompany
    {
        // the relation to both sides
        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
        // many other settings we need
        public virtual string   Description  { get; set; }
        public virtual DateTime CreationDate { get; set; }
        ...
    }
