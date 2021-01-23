      public   class WebAPIManager
        {
            public   ApiAccountLogin ApiAccountLogin(string password, string username)
            {
                return new ApiAccountLogin { Url = "api/Account/Login", Container = new LoginBindingModel() { Password = password, UserName = username } };
            }
        }
    
        public class ApiAccountLogin
        {
            public string Url;
    
            public LoginBindingModel Container;
    
            public ApiAccountLogin(string password, string username)
            {
                Container.Password = password;
                Container.UserName = username;
            }
    
            public ApiAccountLogin()
            {
            }
        }
