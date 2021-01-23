	void Main()
	{
		AutoMapper.Mapper.CreateMap<ChangeNameViewModel, User>();
		
		User user = new User 
		{ 
			FirstName = "Jane", 
			LastName = "Doe", 
			UserId = Guid.NewGuid().ToString() 
		};
		
		ChangeNameViewModel model = new ChangeNameViewModel 
		{ 
			FirstName = "John" 
		};
		
		user = AutoMapper.Mapper.Map<ChangeNameViewModel, User>(model, user);
		
		Console.WriteLine ("First name:  {0}", user.FirstName);
		Console.WriteLine ("Last name:   {0}", user.LastName);
		Console.WriteLine ("UserId: {0}", user.UserId);
		
		// Output should be:
		// ---------------------------
		// First name:  John
		// Last name:   
		// UserId:      9fd25bfd-c978-4287-8d3d-890d67834c23
		// ---------------------------
	}
	
	public class User 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserId { get; set; }
	}
	
	public class ChangeNameViewModel 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
