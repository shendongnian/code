    public class AddressModel
    {
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
    public class StoreModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
