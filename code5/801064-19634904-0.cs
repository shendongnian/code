    public class Customer
    {
        [Key]
        public int ID{get;set;}
    
        public string Name{get;set;}
    
        public string GroupName{get;set;}
    
        public CustomerGroup Group{get;set;}
    }
    
    public class CustomerGroup
    {
        [Key]
        public int ID{get;set;}
    
        public string Name{get;set;}
    
        public List<Customer> Groups{get;set;}
    }
