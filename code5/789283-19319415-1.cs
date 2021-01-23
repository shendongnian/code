    public class FeatureAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public FeatureConst AllowFeature { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //var featureConst = (FeatureConst)filterContext.RouteData.Values["AllowFeature"];
            var filterAttribute = filterContext.ActionDescriptor.GetFilterAttributes(true)
                                    .Where(a => a.GetType() == typeof(FeatureAuthenticationAttribute));
            if (filterAttribute != null)
            {
                foreach (FeatureAuthenticationAttribute attr in filterAttribute)
                {
                    AllowFeature = attr.AllowFeature;
                }
                User currentLoggedInUser = (User)filterContext.HttpContext.Session["CurrentUser"];
                bool allowed = ACLAccessHelper.IsAccessible(AllowFeature.ToString(), currentLoggedInUser);
                // do your logic...
                if (!allowed)
                {
                    string unAuthorizedUrl = new UrlHelper(filterContext.RequestContext).RouteUrl(new { controller = "home", action = "UnAuthorized" });
                    filterContext.HttpContext.Response.Redirect(unAuthorizedUrl);
                }
            }
        }
    }
