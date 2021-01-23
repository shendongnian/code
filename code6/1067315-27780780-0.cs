    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationContext>(options => options.UseSqlServer(
                    Configuration.Get("Data:DefaultConnection:ConnectionString")));
         services.AddDefaultIdentity<ApplicationContext, ApplicationUser, IdentityRole>(Configuration);
         services.AddMvc();
    }
    
