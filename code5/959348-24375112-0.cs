    public static void RegisterRoutes(RouteCollection routes)
            {
                var settings = new FriendlyUrlSettings();
                settings.AutoRedirectMode = RedirectMode.Permanent;
                routes.EnableFriendlyUrls(settings);
                routes.RouteExistingFiles = true;
    
                routes.MapPageRoute("NewsDefault", "news", "~/news/news.aspx");
            }
