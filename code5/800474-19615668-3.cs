    namespace AddressBook.Models
    {
        public class Phone
        {
            public Phone(){}
            public int ID { get; set; }
            public string Number { get; set; }
    
            public virtual Name Name { get; set; }
    
        }
    }
