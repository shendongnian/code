	public interface IUserManagerStrategy
	{
		IUserManager GetManager(string userRole);
	}
    public class UserManagerStrategy
        : IUserManagerStrategy
    {
		private readonly IUserManager[] userManagers;
		
        public UserManagerStrategy(IUserManager[] userManagers)
        {
            if (userManagers == null)
                throw new ArgumentNullException("userManagers");
            this.userManagers = userManagers;
        }
        public IUserManager GetManager(string userRole)
        {
            var manager = this.userManagers.FirstOrDefault(x => x.AppliesTo(userRole));
            if (manager == null && !string.IsNullOrEmpty(userRole))
            {
                // Note that you could optionally specify a default value
                // here instead of throwing an exception.
                throw new Exception(string.Format("User Manager for {0} not found", userRole));
            }
            return manager;
        }
    }
