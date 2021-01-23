    public class LegacyAuthorize : AuthorizeAttribute
    {
      public override void OnAuthorization(HttpActionContext actionContext)
      {
        if (HttpContext.Current.Session["User"] == null)
          base.HandleUnauthorizedRequest(actionContext);
      }
    }
