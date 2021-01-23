    public interface IAuthenticationService
    {
        string GetCurrentUserName();
    }
    
    public class CookieBasedAuthenticationService : IAuthenticationService
    {
     /// ...
    }
