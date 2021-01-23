        public class Client : Person
        {
            public string LastName { get; set; }
    
            public Client()
            {
            }
    
            public Client(Person p) : this()
            {
                FirstName = p.FirstName;
            }
        }
    
