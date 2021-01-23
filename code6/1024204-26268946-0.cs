    public IEnumerable<string> GetUserProperties()
	{
		return typeof(User).GetProperties().Select(property => property.Name);
	}
    public class User
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
