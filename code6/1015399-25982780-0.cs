	void Main()
	{
		AutoMapper.Mapper.CreateMap<ChangeNameViewModel, User>();
		
		var user = new User { FirstName = "Jane", LastName = "Doe", UserId = Guid.NewGuid().ToString() };
		var model = new ChangeNameViewModel { FirstName = "John" };
		
		user = AutoMapper.Mapper.Map<ChangeNameViewModel, User>(model, user);
		
		Console.WriteLine (user.FirstName);
		Console.WriteLine (user.LastName);
		Console.WriteLine (user.UserId);
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
