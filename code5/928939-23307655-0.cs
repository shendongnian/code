    public interface IUserManager
    {
        User Find(string username, string password);
    }
    public class UserManagerImpl : IUserManager
    {
        public User Find(string username, string password)
        {
            return await UserManager.FindAsync(username, password);
        }
    }
    public class AccountController
    {
        private IUserManager _userManager;
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        //user _userManager on your Login method.
    }
