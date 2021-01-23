    [Serializable]
    public class CustomerEntryDTO : DTOBase, IAddressDetails, IAccountDetails
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        public AddressDetails Address { get; set; } //Can remain null for some Customers
        public ICollection<AccountDetails> Accounts { get; set; } //Can remain null for some Customemer
    }
