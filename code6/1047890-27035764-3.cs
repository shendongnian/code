    public class Service
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
    }
    
    public class UserService
    {
        [Key, Column(0)] // this creates a composite key
        public int ServiceId {get;set;}
        [Key, Column(1)] // this creates a composite key
        public string UserId {get;set;}
    }
