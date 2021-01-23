    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, 
            string userName, string password)
        {
            return userName == "john" && password == "test";
        }
    
        public override void OnAuthenticated(IServiceBase authService, 
            IAuthSession session, IAuthTokens tokens, 
            Dictionary<string, string> authInfo)
        {
            //Fill IAuthSession with data you want to retrieve in the app eg:
            session.FirstName = "some_firstname_from_db";
            //...
    
            //Important: You need to save the session!
            authService.SaveSession(session, SessionExpiry);
        }
    }
