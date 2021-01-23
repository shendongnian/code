    public class CustomContact
    {
       public string Name { get; set; }
       public string Number { get; set; }
       public CustomContact()
        {
        }
        //CTOR that takes in a Contact object and extract the two fields we need (can add more fields)
        public CustomContact(Contact contact)
        {
            DisplayName = contact.DisplayName;
            var number = contact.PhoneNumbers.FirstOrDefault();
            if(number != null)
                Number = number.PhoneNumber;
            else
                Number = "";
        }
    }
