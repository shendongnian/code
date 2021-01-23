	public class User
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public virtual ICollection<UserAssociation> Associations { get; set; }
	}
	public class UserAssociation
	{
		public int UserID { get; set; }
		public int FriendID { get; set; }
		
		public DateTime FriendshipDate { get; set; }
		public virtual User User { get; set; }
		public virtual User Friend { get; set; }
	}
