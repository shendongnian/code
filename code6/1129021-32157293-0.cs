     public void ConfigureServices(IServiceCollection services)
      {
    ...
    
     services.AddIdentity<User , Role >() .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
    ...
    }
