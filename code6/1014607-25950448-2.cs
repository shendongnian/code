    /// <summary>
    /// Provides a global <see cref="T:System.Web.Http.HttpConfiguration"/> for ASP.NET applications.
    /// </summary>
    public static class GlobalConfiguration
    {
        private static Lazy<HttpConfiguration> _configuration = CreateConfiguration();
    
        ///... code excluded for brevity
    
        /// <summary>
        /// Gets the global <see cref="T:System.Web.Http.HttpConfiguration"/>.
        /// </summary>
        public static HttpConfiguration Configuration
        {
            get { return _configuration.Value; }
        }
    
        /// <summary>
        /// Performs configuration for <see cref="GlobalConfiguration.Configuration"/> and ensures that it is
        /// initialized.
        /// </summary>
        /// <param name="configurationCallback">The callback that will perform the configuration.</param>
        public static void Configure(Action<HttpConfiguration> configurationCallback)
        {
            if (configurationCallback == null)
            {
                throw new ArgumentNullException("configurationCallback");
            }
    
            configurationCallback.Invoke(Configuration);
            Configuration.EnsureInitialized();
        }
    
        private static Lazy<HttpConfiguration> CreateConfiguration()
        {
            return new Lazy<HttpConfiguration>(() =>
            {
                HttpConfiguration config = new HttpConfiguration(new HostedHttpRouteCollection(RouteTable.Routes));
                ServicesContainer services = config.Services;
                Contract.Assert(services != null);
                services.Replace(typeof(IAssembliesResolver), new WebHostAssembliesResolver());
                services.Replace(typeof(IHttpControllerTypeResolver), new WebHostHttpControllerTypeResolver());
                services.Replace(typeof(IHostBufferPolicySelector), new WebHostBufferPolicySelector());
                services.Replace(typeof(IExceptionHandler),
                    new WebHostExceptionHandler(services.GetExceptionHandler()));
                return config;
            });
        }
    
        ///... code excluded for brevity
    }
