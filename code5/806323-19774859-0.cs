    namespace Web_Test
    {
        public struct TestConnectionParams
        {
            public String username;
            public String password;
        }
        [ServiceContract]
        public interface LoginServiceInterface
        {
            [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
            String TestConnection(TestConnectionParams[] theParams);
        }
    
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
        public class LoginService : LoginServiceInterface
        {
            public String TestConnection(TestConnectionParams[] theParams)
            {
                String ReturnString = "Username is '" + theParams[0].username + ' and Password is {wouldn't you like to know}";
                // actually, password is theParams[0].password
                return ReturnString;
            }
        }
    }
