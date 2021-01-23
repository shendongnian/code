    namespace SuccessEd.Data.Model
    {
        public class Address
        {
            public Adress() {}
            public int AddressId { get; set; }
            public string HomeAddress { get; set; }
            public string BusinessAddress { get; set; }
            public string PoBox { get; set; }
            public virtual Contact Contact { get; set; }
        }
    }
