        [HttpPost]
        public RedirectToRouteResult EditAddress(int id, ContactAddressBindingModel address) {
            // ...
        }
        [HttpPost]
        public RedirectToRouteResult EditContact(int id, ContactBindingModel contact)
        {
            // ...
        }
        public class ContactViewModel : ContactBindingModel
        {
            public IReadOnlyList<IAddress> Addresses { // ...}
        }
        public class ContactBindingModel
        {
            public int? Id { get; set; }
            public string Name { get; set; }
        }
        public class ContactAddressBindingModel : IAddress
        {
            public int? Id { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }
