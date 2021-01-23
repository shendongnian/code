     public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();            
            app.UseWebApi(webApiConfiguration);
        }
        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            // ADD THIS LINE HERE AND DONE
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); 
            config.MapHttpAttributeRoutes();
            return config;
        }
    }
