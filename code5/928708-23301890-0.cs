    public class RequireSSLAttribute : FilterAttribute, IAuthorizationFilter
{
    public virtual void OnAuthorization(AuthorizationContext filterContext)
    {
        if (filterContext == null)
        {
            throw new ArgumentNullException("filterContext");
        }
        if (!filterContext.HttpContext.Request.IsSecureConnection)
        {
            HandleNonHttpsRequest(filterContext);
        }
    }
    protected virtual void HandleNonHttpsRequest(AuthorizationContext filterContext)
    {
        if (filterContext.HttpContext.Request.Url.Host.Contains("localhost")) return;
        if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("The requested resource can only be accessed via SSL");
        }
        string url = "https://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
        filterContext.Result = new RedirectResult(url);
    }
