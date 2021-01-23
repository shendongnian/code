    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext)
                   && Task.Run(() => httpContext.AuthorizePermission(Name, Description, IsGlobal)).Result;
        }
    }
