    public class AuthUserAttribute : AuthorizeAttribute {
    public string[] SecurityGroups;
    public string Groups { get; set; }
    protected override bool AuthorizeCore(HttpContextBase httpContext) {
      bool valid = false;
      var user = UserInformation.Current;
      if (user.SecurityGroups.Select(x => x).Intersect(this.SecurityGroups).Any()) {
        valid = true;
      }
      if (user.SecurityGroups.Select(x => x).Intersect(new string[] { "IT Administrators" }).Any()) {
        valid = true;
      }
      return valid;
    }
    public override void OnAuthorization(AuthorizationContext filterContext) {
      if (!this.AuthorizeCore(filterContext.HttpContext)) {
        if (UserInformation.Current.SecurityGroups.Count == 0) {
          filterContext.Result = new RedirectResult(string.Format("/oa?ReturnUrl={0}", filterContext.HttpContext.Request.RawUrl));
        }
        else {
          filterContext.Result = new RedirectResult(string.Format("/oa/user/permissions?ReturnUrl={0}", filterContext.HttpContext.Request.RawUrl));
        }
      }
      else {
        base.OnAuthorization(filterContext);
      }
    }
