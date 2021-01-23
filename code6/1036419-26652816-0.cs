    public class AuthenticateUser : IAuthenticationFilter
    {
    
        public void OnAuthentication(AuthenticationContext filterContext)
        { 
            if (this.IsAnonymousAction(filterContext))
            {
                return;
            }
            
            // some code
        }
    
        private bool IsAnonymousAction(AuthorizationContext filterContext)
        {
            return  filterContext.ActionDescriptor
                                 .GetCustomAttributes(inherit: true)
                                 .OfType<AllowAnonymousAttribute>() 
                                                 //or any attr. you want
                                 .Any();
        }
    }
