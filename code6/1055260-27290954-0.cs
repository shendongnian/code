    public interface ILoginServiceFactory
    {
        IUserLoginService GetLoginService(string username);
    }
    public class UserLoginServiceFactory : ILoginServiceFactory
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IUserLoginService _adminLoginService;
        public UserLoginServiceFactory(IUserLoginService userLoginService, [Named("AdminLogin")]IUserLoginService adminLoginService)
        {
            _userLoginService = userLoginService;
            _adminLoginService = adminLoginService;
        }
        public IUserLoginService GetLoginService(string username)
        {
            if (username.Contains("@somecompanyname.com")) 
            {
                return _adminLoginService;
            }
            return _userLoginService;
        }
    }
