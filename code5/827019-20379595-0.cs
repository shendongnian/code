	class User
	{
		public int ID { get; protected set; }
		public UserAvatar Avatar { get; set; }
	}
	class UserAvatar
	{
		public int UserID { get; protected set; }
		public User User { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
