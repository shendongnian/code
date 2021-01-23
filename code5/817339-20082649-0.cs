    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public bool IsAdmin {get; set;}
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Load user permissions here
            if(IsAdmin) return user.IsAdmin;
            return false;
        }
    }
