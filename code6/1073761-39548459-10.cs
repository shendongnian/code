    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables()
                            .Build();
        }
    
        public IConfigurationRoot Configuration { get; }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Setup logging
            // Configure app
                
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddOptions();
            // Register our class that reads the DB into the DI framework
            services.AddTransient<IInterfaceForClass, ClassThatNeedsToReadDatabaseUsingLibrary>();
        }
    }
