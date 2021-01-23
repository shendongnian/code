	public class User
	{
		private User() {}
		public string name { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public string email { get; set; }
		public User(string name, string username, string password, string email)
		{
			this.name = name;
			this.username = username;
			this.password = password;
			this.email = email;
		}
	}
