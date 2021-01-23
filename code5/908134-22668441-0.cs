    public interface IAgentAddress
    {
        AddressTypeValues.AddressType AddressType { get; set; }
        String Street1 { get; set; }
        String Street2 { get; set; }
        String Street3 { get; set; }
        String City { get; set; }
        String State { get; set; }
        String ZipCode { get; set; }
    }
