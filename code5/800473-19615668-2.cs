    namespace AddressBook.Models
    {
        public class Name
        {
            public Name ()
            {
              PhoneList = new List<Phone>(); // just so you wont end up with a null reference if you have not yet provided any data.
            }
            public int NameID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            //ref
            public virtual ICollection<Phone> Phones { get; set; }  //added the virtual
        }
    }
