    public abstract DoAuthenticate( AuthenticationContext context );
    ...
    public UserWindowsLogon : User
    {
      public override bool DoAuthenticate( AuthenticationContext context )
      { 
         if ( context is UserWindowsAuthenticationContext )
         {
            // proceed
         }
      }
    }
    public UserApplicationLogon : User
    {
      public override bool DoAuthenticate( AuthenticationContext context )
      {
         if ( context is UserAplicationAuthenticationContext )
         {
            // proceed
         }
       } 
    }
    public abstract class AuthenticationContext { }
    public class UserWindowsAuthenticationContext : AuthenticationContext
    {
       public string windowsDomain;
       public string password;
    }
    public class UserApplicationAuthenticationContext : AuthenticationContext
    {
       public string password;
    }
   
