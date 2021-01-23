    public enum AddressType{
         Work,
         Home,
         Other
    }
    
    class Address{
        public AddressType AddressType{get;set;}
        public AddressLine1 {get;set;}
        public AddressLine2 {get;set;}
        public string City{get;set;}
        public string State{get;set;}
    }
    
    class User
    {
        public int Age{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string HairColor{get;set;}
        public List<Address> AddressList{get;set;}
        public User(){
             AddressList = new List<Address>();
        }
    }
    
    class UserList:List<User>{
    }
