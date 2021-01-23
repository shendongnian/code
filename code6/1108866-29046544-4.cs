    public class AddressViewModel
    { 
        public string City { get; set; }
        public string Street { get; set; }
    }
    public class PersonViewModel()
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressViewModel AddressViewModelTemplate {get; set;}
        public Collection<AddressViewModel> Addresses {get; set;}
    }
