    class Customer
    {
        public string name;
        public string ID {get; set;}
    
        public Customer() 
        { 
        }
    
        public Customer(string n, string id)
        {
            name = n;
            ID = id;
        }
    }
