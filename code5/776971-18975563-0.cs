    [CompletedApplication("User")]
    public ActionResult YourAction
    {
        return View();
    }
    public class CompletedApplicationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Your logic here
            return true;
        }
    }
