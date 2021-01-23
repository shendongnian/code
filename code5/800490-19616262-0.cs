    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual List<FriendShip> FriendShips { get; set; }
        public User()
        {
            FriendShips = new List<FriendShip>();
        }
    }
    public class FriendShip
    {
        public int FriendId { get; set; }
        public virtual User Friend { get; set; }
        public virtual User FriendUser { get; set; }
    }
