    public class MyRoleAuthorization : AuthorizeAttribute
    {
    /// <summary>
    /// the allowed types
    /// </summary>
    readonly string[] allowedTypes;
    
    /// <summary>
    /// Default constructor with the allowed user types
    /// </summary>
    /// <param name="allowedTypes"></param>
    public MyRoleAuthorization(params string[] allowedTypes)
    {
        this.allowedTypes = allowedTypes;
    }
    
    /// <summary>
    /// Gets the allowed types
    /// </summary>
    public string[] AllowedTypes
    {
        get { return this.allowedTypes; }
    }
            
    /// <summary>
    /// Gets the authorize user
    /// </summary>
    /// <param name="filterContext">the context</param>
    /// <returns></returns>
    private string AuthorizeUser(AuthorizationContext filterContext)
    {
        if (filterContext.RequestContext.HttpContext != null)
        {
            var context = filterContext.RequestContext.HttpContext;
            string roleName = Convert.ToString(context.Session["RoleName"]);
            switch (roleName)
            {
                case "Admin":
                case "Employee":
                case "Customer":
                    return roleName;
                default:
                    throw new ArgumentException("filterContext");
            }
        }
        throw new ArgumentException("filterContext");
    }
    
    /// <summary>
    /// The authorization override
    /// </summary>
    /// <param name="filterContext"></param>
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        if (filterContext == null)
            throw new ArgumentException("filterContext");
        string authUser = AuthorizeUser(filterContext);
        if (!this.AllowedTypes.Any(x => x.Equals(authUser, StringComparison.CurrentCultureIgnoreCase)))
        {
            filterContext.Result = new HttpUnauthorizedResult();
            return;
        }
    }
