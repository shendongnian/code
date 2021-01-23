        public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<User> MyFriends { get; set; }
        public virtual ICollection<User> IFriendsForUsers { get; set; }
         
    }
    
