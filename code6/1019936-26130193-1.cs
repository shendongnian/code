    public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
               //...
                System.Web.Http.GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
                config.Formatters.Insert(0, new System.Net.Http.Formatting.JsonMediaTypeFormatter());
                config.Formatters.Insert(0, new System.Net.Http.Formatting.FormUrlEncodedMediaTypeFormatter());
    
                
                config.EnableSystemDiagnosticsTracing();
            }
        }
