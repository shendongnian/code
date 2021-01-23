        public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            HttpServer APIServer = new HttpServer(config);
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.MaxDepth = 2048;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            var odataFormatters = ODataMediaTypeFormatters.Create(new ODataSerialzer(), new ODataDeserialzer());
			config.Formatters.Clear();
			config.Formatters.AddRange(odataFormatters);
            config.MapODataServiceRoute(routeName: "OData",
                routePrefix: "",
                model: APIConfiguration.GetModel(),
                batchHandler: new DefaultODataBatchHandler(APIServer));
        }
    }
