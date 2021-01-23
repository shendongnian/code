      public class Startup
        {
            public void Configuration(IAppBuilder app) 
            {
                var config = new HttpConfiguration();
                config.Formatters.XmlFormatter.UseXmlSerializer = true;
                config.MapHttpAttributeRoutes();
                app.UseWebApi(config);
            }
        }
