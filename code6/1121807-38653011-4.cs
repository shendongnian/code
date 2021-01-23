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
                // During development we won't be using port 443.
                this.sslPort = launchConfiguration.GetValue<int>("iisSettings:iisExpress:sslPort");
            }
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAntiforgery(options =>
                {
                    options.RequireSsl = true;
                });
                .AddMvc(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                    options.SslPort = sslPort;
                });
        }
    
        public void Configure(IApplicationBuilder application)
        {
            application
                .UseHsts(options => options.MaxAge(days: 18 * 7).IncludeSubdomains().Preload())
                .UseHpkp(options => options
                    .Sha256Pins(
                        "Base64 encoded SHA-256 hash of your first certificate e.g. cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=",
                        "Base64 encoded SHA-256 hash of your second backup certificate e.g. M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=")
                    .MaxAge(days: 18 * 7)
                    .IncludeSubdomains())
                .UseCsp(options => options
                    .UpgradeInsecureRequests(this.sslPort.HasValue ? this.sslPort.Value : 443))
                .UseMvc();
        }
    }
