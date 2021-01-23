      public void ConfigureServices(IServiceCollection services)
        {
            // ASPNet Core Identity
            services.AddDbContext<RRIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RRIdentityConnectionString")));
         }
