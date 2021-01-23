    public class MyController : Controller
    {
       private readonly IAuthModule _authModule;
    
       public MyController() : this(new MyAuthModuleWrapper()){}
    
       public MyController(IAuthModule authModule)
       {
          _authModule = authModule;
       }
    
       public ActionResult MyTestAction(string data)
       {
            // ... do whatever is here
            var sessionToken = CreateSessionSecurityToken(CreatePrincipal(claims.ToList()), isPersistent);
            _authModule.WriteSessionTokenToCookie(sessionToken);
            // ... do whatever else
       }
    }
