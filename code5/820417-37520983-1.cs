    [assembly:OwinStartup(typeof(namespace.Startup))]
    public class Startup
        {
            /// <summary> Configurations the specified application. </summary>
            /// <param name="app">The application.</param>
            public static void Configuration(IAppBuilder app)
            {
                var httpConfiguration = CreateHttpConfiguration();
    
                app
                    .UseWebApi(httpConfiguration);
            }
    
         /// <summary> Creates the HTTP configuration. </summary>
            /// <returns> An <see cref="HttpConfiguration"/> to bootstrap the hosted API </returns>
            public static HttpConfiguration CreateHttpConfiguration()
            {
                var httpConfiguration = new HttpConfiguration();
                httpConfiguration.MapHttpAttributeRoutes();
    
                return httpConfiguration;
            }
    }
