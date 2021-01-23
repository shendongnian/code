    public class MyRoleAuthorization : AuthorizeAttribute
    {
        public string Role{get;set;}
        private string AuthorizeUser(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext != null)
            {
                var context = filterContext.RequestContext.HttpContext;
                return (string)context.Session["RoleName"];
            }
            throw new ArgumentException("filterContext");
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentException("filterContext");
            var role = AuthorizeUser(filterContext);
            if (role.Equals(Role))
            {
            // insert positive outcome from role check, ie let the action continue
            }
            else
            {
            // denied! redirect to login page or show denied page (403)
            }
        }
    } 
    [MyRoleAuthorization("Employee")]        
    public ActionResult Index()
    {
        var employee = db.Employee.Include(e => e.User);
        return View(employee.ToList());
    }
