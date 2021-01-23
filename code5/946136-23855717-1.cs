    // Address.cs
    public class Address : BaseEntity
    {
        public StreetAddress Street { get; set; }
    
        public struct StreetAddress
        {
            public int HouseNumber { get; set; }
            public string StreetName { get; set; }
        }
    }
