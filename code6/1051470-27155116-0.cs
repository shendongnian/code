    class User {
        public int Id{get;set;}
        List<UserProperty> UserProperties {get;set;}
    }
    
    class UserProperty{
        public int Id{get;set;}
        public User User {get;set;}
        public string Key {get;set;}
        public string Value {get;set;}
    }
