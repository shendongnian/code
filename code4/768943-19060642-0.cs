    public interface IAuthModule
    {
       void WriteSessionTokenToCookie(Token sessionToken);
    }
    
    public class MyAuthModuleWrapper : IAuthModule
    {
       public void WriteSessionTokenToCookie(Token sessionToken)
       {
           FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
       }
    }
 
