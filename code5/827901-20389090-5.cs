	public class Users
	{
		public string UserId { get; set; }
		[StringLength(30)]
		public string UserName { get; set; }
		[StringLength(20)]
		public string Password { get; set; }
		public DateTime? DateOfRegistration { get; set; }
		public bool IsApproved { get; set; }
	}
