    // your ns above
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // https://stackoverflow.com/questions/41697934/catch-all-exception-in-asp-net-mvc-web-api
            //config.Filters.Add(new ExceptionFilter());
            // ymmv
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // so web api controllers still work
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // this is the stream endpoint route for odata
            config.Routes.MapHttpRoute("myobjdownload", "data/myobj/{id}/content", new { controller = "MyObj", action = "DownloadMyObj" }, null);
            // etc MyObj2
        }
    }
