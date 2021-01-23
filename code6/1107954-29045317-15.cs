	public interface IUserManager
	{
		int Add(User user);
		bool AppliesTo(string userRole);
	}
	
	public class UserManagerA : IUserManager
	{
		// Add method omitted
		
		public bool AppliesTo(string userRole)
		{
            // Note that it is entirely possible to 
            // make this work with multiple roles and/or
            // multiple conditions.
			return (userRole == "RoleA");
		}
	}
	
	public class UserManagerB : IUserManager
	{
		// Add method omitted
		
		public bool AppliesTo(string userRole)
		{
			return (userRole == "RoleB");
		}
	}
