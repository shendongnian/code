    public abstract class ApplicationController : Controller   
    {
        ...
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext); 
            if ( ... )
            {
                // You may find that modifying the 
                // filterContext.HttpContext.User 
                // here works as desired. 
                // In my case I just set it to null
                filterContext.HttpContext.User = null;
            }
        }
        ...
    }
