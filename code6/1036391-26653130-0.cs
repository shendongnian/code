    public class DenyAttribute : AuthorizeAttribute
    {
       private string[] deniedusers;  
       public CustomAuthorizeAttribute(params string[] users)  
       {  
          this.deniedusers = users;  
       }  
       protected override bool AuthorizeCore(HttpContextBase httpContext)  
       {  
          // you could improve this
          return !this.deniedusers.Contains(httpContext.User.Identity.Name);  
       }  
    }
