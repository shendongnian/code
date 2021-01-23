    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Get the ninject kernel from our IoC.
            var kernel = IoC.GetKernel();
            var config = new HttpConfiguration();
            // More config settings and OWIN middleware goes here.
            // Configure camel case json results.
            ConfigureCamelCase(config);
            // Use ninject middleware.
            app.UseNinjectMiddleware(() => kernel);
            // Use ninject web api.
            app.UseNinjectWebApi(config);
        }
        /// <summary>
        /// Configure all JSON responses to have camel case property names.
        /// </summary>
        private void ConfigureCamelCase(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            // This next line is not required for it to work, but here for completeness - ignore data contracts.
            jsonFormatter.UseDataContractJsonSerializer = false;
            var settings = jsonFormatter.SerializerSettings;
    #if DEBUG
            // Pretty json for developers.
            settings.Formatting = Formatting.Indented;
    #else
            settings.Formatting = Formatting.None;
    #endif
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
