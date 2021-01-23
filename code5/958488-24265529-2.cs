    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, 
            string userName, string password)
        {
            return userName == "john" && password == "test";
        }
    }
