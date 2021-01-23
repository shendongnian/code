    public class AddressClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<AddressClass> Address { get; set; }
        public AddressClass()
        {
            Address = new List<AddressClass>();
        }
        public void AddItems(AddressClass item)
        {
            Address.Add(item);
        }
    }
    public class InnerClass
    {
        public string InnerData { get; set; }
    }
