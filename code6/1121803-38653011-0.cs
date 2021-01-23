    public class Startup
    {
        private readonly int? sslPort;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                var launchConfiguration = new ConfigurationBuilder()
                    .SetBasePath(hostingEnvironment.ContentRootPath)
                    .AddJsonFile(@"Properties\launchSettings.json")
                    .Build();
                this.sslPort = launchConfiguration.GetValue<int>("iisSettings:iisExpress:sslPort");
            }
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                // Require HTTPS to be used across the whole site. Also set a custom port to use for SSL in
                // Development. The port number to use is taken from the launchSettings.json file which Visual
                // Studio uses to start the application.
                options.Filters.Add(new RequireHttpsAttribute());
                options.SslPort = sslPort;
            });
        }
    
        ...
    }
