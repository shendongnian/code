    using System.Web.Http;
    using Newtonsoft.Json.Serialization;
    using System.Web.Http.Filters;
    namespace WebServer
    {
        public static class GlobalConfig
        {
            public static void CustomizeConfig(HttpConfiguration config)
            {
                //REGISTER CompressedRequestHandler
                config.MessageHandlers.Add(new CompressedRequestHandler());
                // Remove Xml formatters. This means when we visit an endpoint from a browser,
                // Instead of returning Xml, it will return Json.
                // More information from Dave Ward: http://jpapa.me/P4vdx6
                config.Formatters.Remove(config.Formatters.XmlFormatter);
                // Configure json camelCasing per the following post: http://jpapa.me/NqC2HH
                // Here we configure it to write JSON property names with camel casing
                // without changing our server-side data model:
                //var json = config.Formatters.JsonFormatter;
                //json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //remove standard JSON formatter
                config.Formatters.Remove(config.Formatters.JsonFormatter);
                //add JSONP formatter to support both JSON and JSONP
                var jsonp = new JsonpMediaTypeFormatter();
                jsonp.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonp.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                config.Formatters.Add(jsonp);
                // Add model validation, globally
                config.Filters.Add(new ValidationActionFilter());
                //            config.Filters.Add(new AuthorizeAttribute());
                //
                //config.Filters.Add(new CustomSecurityAttribute());
                //config.Filters.Add(new XchangeSecurityAttribute());
                config.Filters.Add(new ExceptionHandlingAttribute());
            }
        }
    }
