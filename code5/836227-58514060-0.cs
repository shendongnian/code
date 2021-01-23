c#
        public static void Register(HttpConfiguration config)
        {
            ...
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
2. Global.asax.cs
c#
        protected void Application_Start()
        {
            ...
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ...
        }
  [1]: https://stackoverflow.com/a/26171997/8498400
  [2]: https://stackoverflow.com/a/36061041/8498400
  [3]: https://stackoverflow.com/a/45973147/8498400
