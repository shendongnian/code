    public class AddressBaseMap<T> : ClassMap<T> where T : Address
    {
        public AddressBaseMap()
        {
            Map(x => x.Address);
            //etc
        }
    }
    public class CustomerAddressMap : AddressBaseMap<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            Table("CustomerAddress");
        }
    }
