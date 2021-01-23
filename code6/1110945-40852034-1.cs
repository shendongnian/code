       public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var rrIdentityContext = app.ApplicationServices.GetService<RRIdentityDbContext>();
            rrIdentityContext.Database.Migrate();
        }
