    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute("DefaultApi", "api/v1/messages/{action}/{id}", new { controller = "MessagesV1", id = UrlParameter.Optional });
        config.Routes.MapHttpRoute("DefaultApi", "api/v2/messages/{action}/{id}", new { controller = "MessagesV2", id = UrlParameter.Optional });
        config.Routes.MapHttpRoute("DefaultApi", "api/{namespace}/{controller}/{action}/{id}", new { id = UrlParameter.Optional });
    }
