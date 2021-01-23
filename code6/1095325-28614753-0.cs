    public class PersonViewModel
    {
        public PersonViewModel(Person person)
        {
           ...
           MailingAddress = new AddressViewModel(person.address);
        }
        public AddressViewModel MailingAddress { get; private set; }
    }
