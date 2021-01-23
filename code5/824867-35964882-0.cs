    public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings,  new CustomFriendlyUrlResolver());
        }
        public class CustomFriendlyUrlResolver : WebFormsFriendlyUrlResolver
        {
            public override string ConvertToFriendlyUrl(string path)
            {
              
                if (HttpContext.Current.Request.PathInfo != "")
                {
                    return path;
                }
                else
                {
                    return base.ConvertToFriendlyUrl(path);
                }
            }
        }
