	void Main()
	{
		User user = new User 
		{
			FirstName = "Aydin",
			LastName = "Aydin",
			UserId = Guid.NewGuid().ToString()
		};
		
		School school = new School
		{
			SchoolId = Guid.NewGuid().ToString(),
			Name = "Aydins school"
		};
		
		var userProperties = GetProperties(user);
		var schoolProperties = GetProperties(school);
		
		Console.WriteLine ("Retrieving the properties on the User class");
		foreach (var property in userProperties)
		{
			Console.WriteLine ("> {0}", property);
		}
		
		Console.WriteLine ("\nRetrieving the properties on the School class");
		foreach (var property in schoolProperties)
		{
			Console.WriteLine ("> {0}", property);
		}
	}	
		
    public static IEnumerable<string> GetProperties<T>(T t)
	{
		return t.GetType().GetProperties().Select(property => property.Name);
	}
	
	public class User
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
	
	public class School
	{
		public string SchoolId { get; set; }
		public string Name { get; set; }
	}
