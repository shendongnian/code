    public class Address
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address() { }
    }
    public class AddressClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Address> Address { get; set; }
        public AddressClass()
        {
            Address = new List<Address>();
        }
        public void AddItems(Address item)
        {
            Id = item.Id;
            Name = item.Name;
            Address.Add(item);
        }
    }
    public class InnerClass
    {
        public string InnerData { get; set; }
    }
