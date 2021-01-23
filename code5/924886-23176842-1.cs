    class UserFriendship 
    {
        public Guid FriendShipIdGuid {get;set;}
        public Guid UserIdGuid {get;set;}
        public Guid FriendIdGuid {get;set;}
 
        public User User {get;set;}
        public User Friend {get;set;}
    }
    class User 
    {
        public Guid IdGuid {get;set;}
        public string Name {get;set;}
       
        // Only if you will allow duplicates in UserFriendship
        public virtual List<UserFriendship> Friendships {get;set;}
    }
