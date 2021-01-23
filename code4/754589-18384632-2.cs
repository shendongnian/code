    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {  
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            return UserLogUtil.LogUser(authService, userName, password);
        }
    }
    public class CustomBasicAuthProvider : BasicAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            return UserLogUtil.LogUser(authService, userName, password);
        }
    }
